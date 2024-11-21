using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Core.ViewModels.Auth
{
    public class UsuarioOutput
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Plataforma { get; set; }
    }

    public record User(Guid Id, string Name, string Email, string Password, string[] Roles);
}
