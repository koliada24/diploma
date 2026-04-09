using Microsoft.EntityFrameworkCore;
using UserProfiles.API.Database;
using UserProfiles.API.Database.Entities;

namespace UserProfiles.API.Services;

public interface IUserPublicProfilesService
{
    Task<UserPublicProfile> CreateProfileAsync(UserPublicProfile profile, CancellationToken cancellationToken = default);
    Task<UserPublicProfile> UpdateProfileAsync(UserPublicProfile profile, CancellationToken cancellationToken = default);
}

public class UserPublicProfilesService : IUserPublicProfilesService
{
    private readonly AppDbContext _dbContext;

    public UserPublicProfilesService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserPublicProfile> CreateProfileAsync(UserPublicProfile profile, CancellationToken cancellationToken = default)
    {
        if (profile.Id == Guid.Empty)
        {
            throw new ArgumentException("Id must be set.", nameof(profile.Id));
        }

        _dbContext.UserPublicProfiles.Add(profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return profile;
    }

    public async Task<UserPublicProfile> UpdateProfileAsync(UserPublicProfile profile, CancellationToken cancellationToken = default)
    {
        var existingProfile = await _dbContext.UserPublicProfiles
            .FirstOrDefaultAsync(x => x.Id == profile.Id, cancellationToken);

        if (existingProfile is null)
        {
            throw new KeyNotFoundException($"User public profile with id '{profile.Id}' was not found.");
        }

        existingProfile.FirstName = profile.FirstName;
        existingProfile.LastName = profile.LastName;
        existingProfile.Email = profile.Email;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return existingProfile;
    }
}