using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.MVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adınızı unutmayınız!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifrenizi unutmayınız!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [HiddenInput]
        public string? ReturnUrl { get; set; }
    }
}
