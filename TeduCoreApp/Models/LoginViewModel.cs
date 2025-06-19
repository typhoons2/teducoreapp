using System.ComponentModel.DataAnnotations;

namespace TeduCoreApp.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Please enter username")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3-50 characters")]
		[RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers and underscore")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Please enter password")]
		[StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6-100 characters")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
	}
}
