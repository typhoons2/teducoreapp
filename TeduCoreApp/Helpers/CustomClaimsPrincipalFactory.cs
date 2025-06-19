using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Helpers
{
	public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
	{
		UserManager<AppUser> _userManager;
		public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
		{
			_userManager = userManager;
		}
		public override async Task<ClaimsPrincipal> CreateAsync(AppUser user){
			var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;
			if (!identity.HasClaim(c => c.Type == ClaimTypes.Role)){
				var roles = await _userManager.GetRolesAsync(user);
				identity.AddClaims(new[] {
					new Claim("role", string.Join(",", roles))
				});
			}
			var claims = new List<Claim>();
			if (!string.IsNullOrEmpty(user.Email))
				claims.Add(new Claim("email", user.Email));
			if (!string.IsNullOrEmpty(user.FullName))
				claims.Add(new Claim("fullname", user.FullName));
			if (!string.IsNullOrEmpty(user.Avatar))
				claims.Add(new Claim("avatar", user.Avatar));
			identity.AddClaims(claims);
			return principal;
		}
	}
}
