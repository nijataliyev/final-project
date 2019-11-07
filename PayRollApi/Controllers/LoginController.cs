using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PayRollApi.DAL;
using PayRollApi.Models;
using PayRollApi.Models.Page;

namespace PayRollApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PayRollDbContext _db;
        public UserManager<Worker> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        public SignInManager<Worker> _signInManager;

        public LoginController(PayRollDbContext db, SignInManager<Worker> signInManager,UserManager<Worker> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet("login")]
        public ActionResult<IEnumerable<string>> Loginn(string k)
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == login.Username);

                    var isCheck = await _userManager.CheckPasswordAsync(currentUser, login.Password);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, currentUser.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    string token = tokenHandler.WriteToken(securityToken);

                    if (isCheck)
                        return Ok(new { token=token,roles= await _userManager.GetRolesAsync(currentUser) });
                    else
                        return Ok(0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Ok(0);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (ModelState.IsValid)
            {

                try
                {
                    await _signInManager.SignOutAsync();
                    return Ok(1);

                }
                catch(Exception)
                {
                    return Ok(0);
                }
            }
            return Ok(0);
        }
    }
}