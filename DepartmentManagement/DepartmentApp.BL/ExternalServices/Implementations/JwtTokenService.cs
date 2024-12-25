using DepartmentApp.BL.ExternalServices.Abstractions;
using DepartmentApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DepartmentApp.BL.ExternalServices.Implementations;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //public string GenerateToken(AppUser user)
    //{
    //    List<Claim> claims = new List<Claim>()
    //    {
    //        new Claim("FirstName", user.FirstName),
    //        new Claim(ClaimTypes.Name,user.UserName),
    //        new Claim(ClaimTypes.NameIdentifier,user.Id)
    //    };

    //    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
    //    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims, issuer: _configuration["Jwt:Issuer"],
    //        audience: _configuration["Jwt:Audience"], signingCredentials: signingCredentials, expires: DateTime.UtcNow.AddMinutes(10));
    //    return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    //}
    public string GenerateToken(AppUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }

        var claims = new List<Claim>
    {
        new Claim("FirstName", user.FirstName), 
        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
        new Claim(ClaimTypes.NameIdentifier, user.Id) 
    };

        var secretKey = _configuration["Jwt:SecretKey"];
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("SecretKey is missing in the configuration.");
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

}
