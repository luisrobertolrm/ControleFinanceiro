using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            User? user = await _userService.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Unauthorized("Invalid credentials 1");
            }

            var saltedPassword = request.Password + user.Salt;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, saltedPassword);

            if (result != PasswordVerificationResult.Success)
            {
                return Unauthorized("Invalid credentials 2");
            }

            // Generate token
            var token = _tokenService.CreateToken(user);

            // Return the token
            return Ok(new AuthResponse { Token = token });
        }
    }
}
