using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserProfiles.API.Models;
using UserProfiles.API.Services;

namespace UserProfiles.API.Controllers;

[Route("groups")]
[Authorize]
public class StudentsGroupsController : ControllerBase
{
    private readonly IStudentsGroupsService _studentsGroupsService;

    public StudentsGroupsController(IStudentsGroupsService studentsGroupsService)
    {
        _studentsGroupsService = studentsGroupsService;
    }

    [HttpPost]
    public async Task<ActionResult<StudentsGroupDto>> CreateStudentsGroup(
        [FromBody] CreateStudentsGroupDto createDto,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _studentsGroupsService.CreateStudentsGroupAsync(createDto, cancellationToken);
            return CreatedAtAction(
                nameof(GetStudentsGroupById),
                new { id = result.Id },
                result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentsGroupDto>>> GetAllStudentsGroups(
        CancellationToken cancellationToken = default)
    {
        var userId = GetCurrentUserId();
        if (userId == null)
        {
            return Unauthorized("User ID not found in token");
        }

        try
        {
            var result = await _studentsGroupsService.GetAllStudentsGroupsForUserAsync(userId.Value, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentsGroupDto>> GetStudentsGroupById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _studentsGroupsService.GetStudentsGroupByIdAsync(id, cancellationToken);
            
            if (result == null)
            {
                return NotFound($"Students group with ID {id} not found");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<StudentsGroupDto>> UpdateStudentsGroup(
        Guid id,
        [FromBody] UpdateStudentsGroupDto updateDto,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _studentsGroupsService.UpdateGeneralStudentsGroupInfoAsync(id, updateDto, cancellationToken);
            
            var updatedGroup = await _studentsGroupsService.GetStudentsGroupByIdAsync(id, cancellationToken);
            return Ok(updatedGroup);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteStudentsGroup(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _studentsGroupsService.DeleteStudentsGroupAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("students")]
    public async Task<ActionResult<StudentsGroupDto>> AddStudentToGroup(
        [FromBody] AddStudentToGroupDto addStudentDto,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _studentsGroupsService.AddStudentToStudentsGroupAsync(addStudentDto, cancellationToken);
            
            var updatedGroup = await _studentsGroupsService.GetStudentsGroupByIdAsync(
                addStudentDto.GroupId, cancellationToken);
            
            return Ok(updatedGroup);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{groupId:guid}/students/{studentId:guid}")]
    public async Task<ActionResult<StudentsGroupDto>> RemoveStudentFromGroup(
        Guid groupId,
        Guid studentId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _studentsGroupsService.RemoveStudentFromStudentsGroupAsync(groupId, studentId, cancellationToken);
            
            var updatedGroup = await _studentsGroupsService.GetStudentsGroupByIdAsync(groupId, cancellationToken);
            return Ok(updatedGroup);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("{groupId:guid}/students/{studentId:guid}")]
    public async Task<ActionResult<StudentsGroupDto>> AddStudentToGroupByRoute(
        Guid groupId,
        Guid studentId,
        CancellationToken cancellationToken = default)
    {
        var addStudentDto = new AddStudentToGroupDto
        {
            GroupId = groupId,
            StudentId = studentId
        };

        try
        {
            await _studentsGroupsService.AddStudentToStudentsGroupAsync(addStudentDto, cancellationToken);
            
            var updatedGroup = await _studentsGroupsService.GetStudentsGroupByIdAsync(groupId, cancellationToken);
            return Ok(updatedGroup);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private Guid? GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            return null;
        }

        return userId;
    }
}