using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using NewLibrary.Models;

namespace NewLibrary.ConfigJWT;

    public class JWT
    {
    private const string nameIdentifier = ClaimTypes.NameIdentifier;

    public static string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(nameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
        };

        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
        var jwtExpiresIn = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN");

        // Validar que las variables existen
        if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
        {
            throw new InvalidOperationException("JWT configuration values are missing.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtExpiresIn)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    internal static object GenerateJwtToken(ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }
}
