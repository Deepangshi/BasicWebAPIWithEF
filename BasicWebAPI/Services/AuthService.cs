using BasicWebAPI.Context;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using BasicWebAPI.Request_Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicWebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly APIDbContext _apidbService;
        private readonly IConfiguration _configuration;
        public AuthService(APIDbContext apidbContext, IConfiguration configuration) {
            _apidbService = apidbContext;
            _configuration = configuration;
        }
        public User AddUser(User user)
        {
            var addeduser = _apidbService.Add(user);
            _apidbService.SaveChanges();
            return addeduser.Entity;
        }

        //JWT 
        public string Login(LoginRequest loginRequest)
        {
            if(loginRequest.Useremail!= null && loginRequest.Password!= null)
            {
                var user = _apidbService.Users.SingleOrDefault(s => s.Email == loginRequest.Useremail && s.Password == loginRequest.Password);
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email", user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddHours(3),
                        signingCredentials: signIn
                        );
                    var jwtToken = (new JwtSecurityTokenHandler().WriteToken(token));
                    return jwtToken;

                }
                else 
                {
                    throw new Exception("invalid user!");
                }
            }
            else 
            {
                throw new Exception("invalid credential!");
            }
        }
    }
}
