using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Infrastructure.Identity.Entities;

namespace TeduCoreApp.Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<AppUser> GetUserByIdAsync(Guid userId)
        {
            var identityUser = await _userManager.FindByIdAsync(userId.ToString());
            if (identityUser == null)
                return null;

            return _mapper.Map<AppUser>(identityUser);
        }

        public async Task<bool> CreateUserAsync(AppUser user, string password)
        {
            var identityUser = _mapper.Map<ApplicationUser>(user);
            var result = await _userManager.CreateAsync(identityUser, password);
            
            if (result.Succeeded)
            {
                // Map back the generated Id
                user.Id = identityUser.Id;
                return true;
            }
            
            return false;
        }

        public async Task<bool> UpdateUserAsync(AppUser user)
        {
            var identityUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (identityUser == null)
                return false;

            // Map only the properties we want to update
            identityUser.FullName = user.FullName;
            identityUser.BirthDay = user.BirthDay;
            identityUser.Balance = user.Balance;
            identityUser.Avatar = user.Avatar;
            identityUser.Status = user.Status;

            var result = await _userManager.UpdateAsync(identityUser);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var identityUser = await _userManager.FindByIdAsync(userId.ToString());
            if (identityUser == null)
                return false;

            var result = await _userManager.DeleteAsync(identityUser);
            return result.Succeeded;
        }

        public async Task<AppRole> GetRoleByIdAsync(Guid roleId)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId.ToString());
            if (identityRole == null)
                return null;

            return _mapper.Map<AppRole>(identityRole);
        }

        public async Task<bool> CreateRoleAsync(AppRole role)
        {
            var identityRole = _mapper.Map<ApplicationRole>(role);
            var result = await _roleManager.CreateAsync(identityRole);
            
            if (result.Succeeded)
            {
                // Map back the generated Id
                role.Id = identityRole.Id;
                return true;
            }
            
            return false;
        }

        public async Task<bool> UpdateRoleAsync(AppRole role)
        {
            var identityRole = await _roleManager.FindByIdAsync(role.Id.ToString());
            if (identityRole == null)
                return false;

            identityRole.Name = role.Name;
            identityRole.Description = role.Description;

            var result = await _roleManager.UpdateAsync(identityRole);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(Guid roleId)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId.ToString());
            if (identityRole == null)
                return false;

            var result = await _roleManager.DeleteAsync(identityRole);
            return result.Succeeded;
        }
    }
} 