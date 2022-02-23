

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreCamp.Models
{
    public class UserSignUpViewModel
    {
        [DisplayName(displayName:"Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }

        [DisplayName(displayName: "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }


        [DisplayName(displayName: "Şifre Tekrar")]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [DisplayName(displayName: "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string Mail { get; set; }

        [DisplayName(displayName: "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }
    }
}
