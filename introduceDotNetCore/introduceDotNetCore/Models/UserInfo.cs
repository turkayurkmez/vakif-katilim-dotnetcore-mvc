using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace introduceDotNetCore.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "Adınız boş olamaz")]
        [MinLength(3, ErrorMessage = "En az üç harf...")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Eposta boş olamaz")]
        public string Email { get; set; }
        public int? Age { get; set; }
        public bool? IsParticipate { get; set; }
    }
}

