﻿using HospitalProjectServer.DataAccess.Options;
using HospitalProjectServer.Entities.DTOs;
using HospitalProjectServer.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalProjectServer.DataAccess.Services;
public class JwtProvider(
    UserManager<User> userManager,
    IOptions<JwtOptions> jwtOptions)
{
    public async Task<LoginResponseDto> CreateToken(User user, bool rememberMe)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.FullName),
            new Claim (ClaimTypes.Email,user.Email ?? ""),
            new Claim("UserName",user.UserName??"")
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

        DateTime expires = DateTime.UtcNow.AddHours(4);

        if (rememberMe)
        {
            expires = expires.AddDays(1);
        }

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512)
            );


        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtSecurityToken);

        string refreshToken = Guid.NewGuid().ToString();
        DateTime refreshTokenExpires = expires.AddHours(1);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshTokenExpires;

        await userManager.UpdateAsync(user);

        return new(token, refreshToken, refreshTokenExpires);
    }
}
