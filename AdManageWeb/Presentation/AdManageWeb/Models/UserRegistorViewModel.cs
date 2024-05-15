using System.ComponentModel.DataAnnotations;

namespace AdManage.Models
{
	public class UserRegistorViewModel
	{
		[Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
		public string Name { get; set; } = "yusuf";

		[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
		public string SurName { get; set; } = "Aras";

		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string UserName { get; set; } = "yusuf";

		[Required(ErrorMessage = "Lütfen mail adresinizi Giriniz")]
		public string Mail { get; set; } = "yusuf@gmail.com";

		[Required(ErrorMessage = "Lütfen şifrenizi Giriniz")]
		public string Password { get; set; } = "Yusuf.123";

		[Required(ErrorMessage = "Lütfen şifrenizi tekrar Giriniz")]
		[Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
		public string ConifrmPassword { get; set; } = "Yusuf.123";


	}
}