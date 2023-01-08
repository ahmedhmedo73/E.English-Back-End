using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Gp1.Controllers
{

    public class UserForm
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? repassword { get; set; }
        public int? age { get; set; }
        public string? gender { get; set; }
        public string? email { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class UserController : ControllerBase
    {
        private DB _db;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public UserController(DB db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UserForm userform)
        {
            if (userform.password != userform.repassword)
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string>
                {
                    "your Password not matched"
                }
                });
            }

            ApplicationUser user = new ApplicationUser();
            user.Fname = userform.Fname;
            user.Lname = userform.Lname;
            user.UserName = userform.username;
            user.Age = userform.age ?? 0;
            user.Gender = userform.gender;
            user.Email = userform.email;
            user.CreationTime = DateTime.UtcNow;
            var userInDb = await _userManager.FindByEmailAsync(user.Email);
            if (userInDb != null)
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string>
                    {
                        "User Is Already Exist"
                    }
                });

            }
            else
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                    Data = await CreateUser(user, userform.password)
                });


            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = await _db.Users.Where(s => !s.UserRoles.Any(c => c.Role.Name == Roles.Admin.ToString())).ToListAsync()
            });

        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string? id)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = await _userManager.FindByIdAsync(id)
            });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUesr(string id)
        {
            try
            {
                ApplicationUser user = _db.Users.FirstOrDefault(s => s.Id == id);
                if (user != null)
                {

                    _db.Users.Remove(user);
                    await _db.SaveChangesAsync();
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Succeeded.ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Failed.ToString(),
                Errors = new List<string>
                {
                    "Isnot Deleted"
                }
            });
        }

        private async Task<string> CreateUser(ApplicationUser user, string password)
        {
            var userCreated = await _userManager.CreateAsync(user, password);
            if (userCreated.Succeeded)
            {
                if (await _roleManager.RoleExistsAsync(Roles.User.ToString()))
                {
                    var assignToRole = await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                    if (assignToRole.Succeeded)
                    {
                        return "User Is Created";
                    }
                    else return string.Join(" , ", assignToRole.Errors.Select(s => s.Description));

                }
                else
                {
                    var roleCreated = await _roleManager.CreateAsync(new ApplicationRole { Id = Guid.NewGuid().ToString() + Guid.NewGuid().ToString(), Name = Roles.User.ToString() });
                    if (roleCreated.Succeeded)
                    {
                        var assignToRole = await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                        if (assignToRole.Succeeded)
                        {
                            return "User Is Created";
                        }
                        else return string.Join(" , ", assignToRole.Errors.Select(s => s.Description));

                    }
                    else
                    {
                        return string.Join(" , ", roleCreated.Errors.Select(s => s.Description));
                    }
                }
            }
            else
            {
                return string.Join(" , ", userCreated.Errors.Select(s => s.Description));

            }
        }
    }
}
