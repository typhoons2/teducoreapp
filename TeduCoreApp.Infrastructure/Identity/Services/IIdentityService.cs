using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Identity.Services
{
    public interface IIdentityService
    {
        Task<AppUser> GetUserByIdAsync(Guid userId);
        Task<bool> CreateUserAsync(AppUser user, string password);
        Task<bool> UpdateUserAsync(AppUser user);
        Task<bool> DeleteUserAsync(Guid userId);

        Task<AppRole> GetRoleByIdAsync(Guid roleId);
        Task<bool> CreateRoleAsync(AppRole role);
        Task<bool> UpdateRoleAsync(AppRole role);
        Task<bool> DeleteRoleAsync(Guid roleId);
    }
} 