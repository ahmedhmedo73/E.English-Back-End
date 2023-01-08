using Gp1.model;
using Gp1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly DB _db;
        readonly IAuthService _authService;
        readonly UserManager<ApplicationUser> _userManager;
        readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(DB db, IAuthService authService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _db = db;
            _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> login([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMyAdminUsers()
        {
            var errors = Enumerable.Empty<string>();
            try
            {
                var myUser = new ApplicationUser
                {
                    Fname = "Admin2",
                    Lname = "Admin2",
                    UserName = "admin2@gmail.com",
                    Email = "admin2@gmail.com",
                    Age = 23,
                    Gender = "Male",
                    CreationTime = DateTime.UtcNow,
                };
                string pass = "Mm.123456";
                var userInDb = await _userManager.FindByEmailAsync(myUser.Email);
                if (userInDb == null)
                {
                    var result = await _userManager.CreateAsync(myUser, pass);
                    if (result.Succeeded)
                    {
                        if (await _roleManager.RoleExistsAsync(Roles.Admin.ToString()))
                        {
                            var assignedResult = await _userManager.AddToRoleAsync(myUser, Roles.Admin.ToString());
                            if (assignedResult.Succeeded)
                            {

                                return Ok(new { msg = "created successfully" });
                            }
                            else
                            {
                                errors = assignedResult.Errors.Select(s => s.Description);
                            }
                        }
                        else
                        {

                            var roleCreated = await _roleManager.CreateAsync(new ApplicationRole { Id = Guid.NewGuid().ToString() + Guid.NewGuid().ToString(), Name = Roles.Admin.ToString() });
                            if (roleCreated.Succeeded)
                            {
                                var assignedResult = await _userManager.AddToRoleAsync(myUser, Roles.Admin.ToString());
                                if (assignedResult.Succeeded)
                                {

                                    return Ok(new { msg = "created successfully" });
                                }
                                else
                                {
                                    errors = assignedResult.Errors.Select(s => s.Description);
                                }
                            }
                            else
                            {
                                errors = roleCreated.Errors.Select(s => s.Description);
                            }
                        }
                    }
                    else
                    {
                        errors = result.Errors.Select(s => s.Description);
                    }

                }
                else return Ok("User Exist");
            }
            catch (Exception ex)
            {

            }

            return Ok(new { msg = "error", errors });
        }


    }
}
