﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymCore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GymCore.API.Services
{
    public class JwtManager
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public int ExpirationTime { get; set; }

        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JWTSettings");
            ExpirationTime = _jwtSettings.GetValue<int>("expiryInSeconds");
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public static List<Claim> GetClaims(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email)
            };

            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
               issuer: _jwtSettings.GetSection("validIssuer").Value,
               audience: _jwtSettings.GetSection("validAudience").Value,
               claims: claims,
               expires: DateTime.Now.AddSeconds(Convert.ToDouble(_jwtSettings.GetSection("expiryInSeconds").Value)),
               signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
