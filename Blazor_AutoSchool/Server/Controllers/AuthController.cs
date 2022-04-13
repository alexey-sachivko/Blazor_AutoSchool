using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_AutoSchool.Server.Controllers
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

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _authService.Login(request.Username, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _authService.Register(new Employee
            {
                Surname = request.Surname,
                Name = request.Name,
                ThirdName = request.ThirdName,
                Birthday = request.Birthday,
                Address = request.Address,
                Contact = request.Contact,
                Passport = request.Passport,
                Username = request.Username,
                Role = request.Role
            }, request.Password);
            
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
