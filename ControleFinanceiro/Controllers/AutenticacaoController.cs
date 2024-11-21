using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.ViewModels.Auth;
using ControleFinanceiro.Jwt;
using ControleFinanceiro.Core.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly TokenUtil _tokenUtils;

        public AutenticacaoController(TokenUtil tokenUtils)
        {
            _tokenUtils = tokenUtils;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginInput request)
        {
            var usuario = new User (Guid.NewGuid(), "Luis", request.Email, "Teste", new string[]{ "Usuario"});

            var token = this._tokenUtils.CreateToken(usuario);

            return Ok(new LoginOutput { Username = "Teste", Token = token });
        }
    }
}
