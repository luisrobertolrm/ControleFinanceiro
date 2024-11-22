using AutoMapper;
using ControleFinanceiro.Core.ViewModels.Auth;
using ControleFinanceiro.Negocio;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleFinanceiro.Jwt
{
    public class TokenUtil
    {
        private readonly IConfiguration _configuration;

        public TokenUtil(IConfiguration config)
        {
            this._configuration = config;
        }

        public string CreateToken(User user)
        {

            var issuer = this._configuration["JwtConfig:Issuer"];
            var audience = this._configuration["JwtConfig:Audience"];
            var key = this._configuration["JwtConfig:Key"];
            var tokenValidityMins = this._configuration.GetValue<int>("JwtConfig:TokenValidityMins");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new[] { new Claim(JwtRegisteredClaimNames.Name, user.Name) }),
                Expires = tokenExpiryTimeStamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var acessToken = tokenHandler.WriteToken(securityToken);

            return acessToken;
        }


        private static ClaimsIdentity GenerateClaims(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Name, user.Email));

            foreach (var role in user.Roles)
                claims.AddClaim(new Claim(ClaimTypes.Role, role));

            return claims;
        }
    }

}
