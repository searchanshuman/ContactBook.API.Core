using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ContactBook.API.Models;
using ContactBook.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ContactBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IConfiguration config, IAuthenticateService authenticateService)
        {
            _config = config;
            _authenticateService = authenticateService;
        }

        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate(User login)
        {
            IActionResult response = Unauthorized(new { message = "User Name or Password is incorrect " });
            var user = _authenticateService.Authenticate(login.UserName, login.Password);

            if (user != null)
                response = Ok(user);
            
            return response;
        }
    }
}
