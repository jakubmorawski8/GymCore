using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.API.Services;
using GymCore.Application.Requests;
using GymCore.Application.Responses;
using GymCore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymCore.API.Controllers
{
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly JwtManager _jwtManager;
        private readonly IMapper _mapper;
        public AccountsController(UserManager<UserEntity> userManager, JwtManager jwtManager, IMapper mapper)
        {
            _userManager = userManager;
            _jwtManager = jwtManager;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var response = new AuthResponse()
                {
                    Message = "Invalid credentials.",
                    Success = false
                };
                return Unauthorized(response);
            }

            var claims = JwtManager.GetClaims(user);
            var signingCredentials = _jwtManager.GetSigningCredentials();
            var tokenOptions = _jwtManager.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponse { Token = token, ExpiresIn = _jwtManager.ExpirationTime });
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(AuthRequest request)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);

            if (userExist != null)
            {
                return BadRequest(new AuthResponse { Message = "Email already exists." });
            }

            var user = _mapper.Map<UserEntity>(request);

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new AuthResponse { Message = e.Message });
            }
        }
    }
}
