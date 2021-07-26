using ContactBook.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.API.Services
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public class AuthenticateService : IAuthenticateService
    {
        private IConfiguration _config;

        private List<User> users = new List<User>()
        {
            new User{ UserId=1, FirstName="Amit", LastName="Kumar", Password="@mitkumar123", UserName="amit.kumar", Role=UserRoles.Admin, Token="" },
            new User{ UserId=1, FirstName="Ravi", LastName="Singh", Password="r@visingh123", UserName="ravi.singh", Role=UserRoles.User, Token="" }
        };

        public AuthenticateService(IConfiguration config)
        {
            _config = config;
        }
        public User Authenticate(string userName, string password)
        {
            var user = users.SingleOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));

            //Return Null if user is not found
            if (user == null)
                return null;

            //If user is found
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Version, "v3.1"),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            user.Password = null;
            user.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return user;
        }
    }
}
