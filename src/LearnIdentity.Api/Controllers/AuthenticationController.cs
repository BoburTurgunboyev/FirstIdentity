using LearnIdentity.Api.Models;
using LearnIdentity.Api.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearnIdentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Registor( [FromBody] RegistorUser registorUser,string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registorUser.Email);    
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User Already exists" });
            }

            //Add User to database
            IdentityUser user = new()
            {
                Email = registorUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),  
                UserName = registorUser.UserName,
            };
            if(await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registorUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "User Failed to Create" });
                }

               //Add Role to  the User

                await _userManager.AddToRoleAsync(user, role);

                //Add Token to verify the email
              


                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = "User  Created Successfully" });

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "This Role Doesnot Exists" });

            }
                
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                var result  = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Error",Message= "Email Verified Successfully" });
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error",Message="This User doesnot exist" });

        }


    }
}
