using System.ComponentModel.DataAnnotations;

namespace TeduCoreApp.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3-50 ký tự")]
		[RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-100 ký tự")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Ghi nhớ đăng nhập")]
		public bool RememberMe { get; set; }
	}
}
