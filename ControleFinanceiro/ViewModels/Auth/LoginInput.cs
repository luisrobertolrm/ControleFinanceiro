using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.ViewModels.Auth
{
    public class LoginInput
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
