using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using BasicWebAPI.Request_Models;
using Microsoft.AspNetCore.Mvc;


namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService; 
        }


        // POST api/<AuthController>
        [HttpPost]
        public string Login([FromBody] LoginRequest loginRequest)
        {
            var result = _authService.Login(loginRequest);
            return result;
        }

        // POST api/<AuthController>/5
        [HttpPost("registerUser")]
        public User AddUser([FromBody] User value)
        {
            var user = _authService.AddUser(value);
                return user;
        }


    }
}
