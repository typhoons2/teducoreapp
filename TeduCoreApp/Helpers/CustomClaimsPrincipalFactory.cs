using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TeduCoreApp.Infrastructure.Identity.Entities;

namespace TeduCoreApp.Helpers
{
	public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public CustomClaimsPrincipalFactory(
			UserManager<ApplicationUser> userManager, 
			RoleManager<ApplicationRole> roleManager, 
			IOptions<IdentityOptions> options) 
			: base(userManager, roleManager, options)
		{
			_userManager = userManager;
		}

		public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
		{
			var principal = await base.CreateAsync(user);
			
			if (principal?.Identity is not ClaimsIdentity identity)
			{
				throw new InvalidOperationException("Failed to create claims identity");
			}

			// Add roles if not already present
			if (!identity.HasClaim(c => c.Type == ClaimTypes.Role))
			{
				var roles = await _userManager.GetRolesAsync(user);
				if (roles.Any())
				{
					identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(";", roles)));
				}
			}

			// Add custom claims
			var claims = new List<Claim>();

			if (!string.IsNullOrEmpty(user.Email))
			{
				claims.Add(new Claim(ClaimTypes.Email, user.Email));
			}

			if (!string.IsNullOrEmpty(user.FullName))
			{
				claims.Add(new Claim(ClaimConstants.FullName, user.FullName));
			}

			if (!string.IsNullOrEmpty(user.Avatar))
			{
				claims.Add(new Claim(ClaimConstants.Avatar, user.Avatar));
			}

			identity.AddClaims(claims);
			return principal;
		}
	}
}
