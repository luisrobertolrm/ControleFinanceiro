using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Core.ViewModels.Auth
{
    public class UsuarioInput
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Plataforma { get; set; }
    }
}
