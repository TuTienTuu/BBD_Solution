using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.System.Users;

namespace Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly RoleManager<EmployeeRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<Employee> userManager, SignInManager<Employee> signInManager, IConfiguration config, RoleManager<EmployeeRole> roleManager)
        { 
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _roleManager = roleManager;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var result =await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName ),
                new Claim(ClaimTypes.Email,user.Email ),
                new Claim(ClaimTypes.Role,String.Join(",",roles)),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issue"],
                _config["Tokens:Issue"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new Employee()
            {
                UserName = request.UserName,
                Address = request.Address,
                Birthday = request.Birthday,
                IdentityNumber = request.IdentityNumber,
                IdentitDated = request.IdentitDated,
                IsOff = false,
                OffDate = DateTime.MinValue,
                OnDate = request.OnDate,
                Password = request.Password,
                PlaceIssued = request.PlaceIssued,
                TemporaryAddress = request.TemporaryAddress,


            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;   
        }
    }
}
