using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTe.Models.Entities
{
    public class LogonViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-mail:")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha:")]
        public string? Senha { get; set; }

        [Display(Name = "Lembrar-me")]

        public bool RememberMe { get; set; }
    }
}
