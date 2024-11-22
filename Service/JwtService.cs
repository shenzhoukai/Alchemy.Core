using Alchemy.Core.Extension;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Alchemy.Core.Service
{
    public class JwtService
    {
        public static string GenerateJwtToken(string strSecretKey, string strIssuer, string strAudience, Dictionary<string, object> claims, int expireInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strSecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = strIssuer,
                Audience = strAudience,
                SigningCredentials = credentials,
                Claims = claims,
                Expires = DateTime.UtcNow.AddMinutes(expireInMinutes)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        public static bool DecodeJwtToken(string strSecretKey, string strToken, out List<Claim> claims)
        {
            bool result = false;
            claims = new List<Claim>();
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(strSecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                // 其他可能需要的验证参数
            };
            try
            {
                SecurityToken validatedToken;
                var principal = handler.ValidateToken(strToken, validationParameters, out validatedToken);
                var jwtToken = validatedToken as JwtSecurityToken;
                if(jwtToken.IsNotNull())
                {
                    claims = jwtToken.Claims.ToList();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Token validation failed: {ex.Message}");
            }
            return result;
        }
    }
}
