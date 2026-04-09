using Microsoft.EntityFrameworkCore;
using UserProfiles.API.Database;
using UserProfiles.API.Database.Entities;
using UserProfiles.API.Models;

namespace UserProfiles.API.Services;

public interface IStudentsGroupsService
{
    Task<StudentsGroupDto> CreateStudentsGroupAsync(CreateStudentsGroupDto createDto, CancellationToken cancellationToken = default);
    Task DeleteStudentsGroupAsync(Guid studentsGroupId, CancellationToken cancellationToken = default);
    Task UpdateGeneralStudentsGroupInfoAsync(Guid id, UpdateStudentsGroupDto updateDto, CancellationToken cancellationToken = default);
    Task<List<StudentsGroupDto>> GetAllStudentsGroupsForUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<StudentsGroupDto?> GetStudentsGroupByIdAsync(Guid studentsGroupId, CancellationToken cancellationToken = default);
    Task AddStudentToStudentsGroupAsync(AddStudentToGroupDto addStudentDto, CancellationToken cancellationToken = default);
    Task RemoveStudentFromStudentsGroupAsync(Guid studentsGroupId, Guid studentId, CancellationToken cancellationToken = default);
}

public class StudentsGroupsService : IStudentsGroupsService
{
    private readonly AppDbContext _dbContext;

    public StudentsGroupsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<StudentsGroupDto> CreateStudentsGroupAsync(CreateStudentsGroupDto createDto, CancellationToken cancellationToken = default)
    {
        var studentsGroup = new StudentsGroup
        {
            Id = Guid.NewGuid(),
            Name = createDto.Name,
            Description = createDto.Description,
            CreatedBy = createDto.CreatedBy
        };

        _dbContext.StudentsGroups.Add(studentsGroup);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return MapToDto(studentsGroup);
    }

    public async Task DeleteStudentsGroupAsync(Guid studentsGroupId, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.StudentsGroups
            .FirstOrDefaultAsync(x => x.Id == studentsGroupId, cancellationToken);

        if (group is null)
        {
            throw new KeyNotFoundException($"Students group with id '{studentsGroupId}' was not found.");
        }

        _dbContext.StudentsGroups.Remove(group);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateGeneralStudentsGroupInfoAsync(Guid id, UpdateStudentsGroupDto updateDto, CancellationToken cancellationToken = default)
    {
        var existingGroup = await _dbContext.StudentsGroups
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingGroup is null)
        {
            throw new KeyNotFoundException($"Students group with id '{id}' was not found.");
        }

        existingGroup.Name = updateDto.Name;
        existingGroup.Description = updateDto.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<StudentsGroupDto>> GetAllStudentsGroupsForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var groups = await _dbContext.StudentsGroups
            .Where(x => x.CreatedBy == userId)
            .ToListAsync(cancellationToken);

        return groups.Select(MapToDto).ToList();
    }

    public async Task<StudentsGroupDto?> GetStudentsGroupByIdAsync(Guid studentsGroupId, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.StudentsGroups
            .FirstOrDefaultAsync(x => x.Id == studentsGroupId, cancellationToken);

        return group != null ? MapToDto(group) : null;
    }

    public async Task AddStudentToStudentsGroupAsync(AddStudentToGroupDto addStudentDto, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.StudentsGroups
            .FirstOrDefaultAsync(x => x.Id == addStudentDto.GroupId, cancellationToken);

        if (group is null)
        {
            throw new KeyNotFoundException($"Students group with id '{addStudentDto.GroupId}' was not found.");
        }

        if (!group.StudentIds.Contains(addStudentDto.StudentId))
        {
            group.StudentIds.Add(addStudentDto.StudentId);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task RemoveStudentFromStudentsGroupAsync(Guid studentsGroupId, Guid studentId, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.StudentsGroups
            .FirstOrDefaultAsync(x => x.Id == studentsGroupId, cancellationToken);

        if (group is null)
        {
            throw new KeyNotFoundException($"Students group with id '{studentsGroupId}' was not found.");
        }

        group.StudentIds.Remove(studentId);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private static StudentsGroupDto MapToDto(StudentsGroup entity)
    {
        return new StudentsGroupDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            StudentIds = entity.StudentIds,
            CreatedBy = entity.CreatedBy
        };
    }
}