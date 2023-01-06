using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ManageController : ControllerBase
    {

        readonly DB _db;
        readonly IMapper _mapper;
        readonly UserManager<ApplicationUser> _userManager;
        readonly IWebHostEnvironment _webHostEnvironment;

        public ManageController(DB db, IMapper mapper, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(userId))
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string>
                    {
                        "an error occured"
                    }
                });

            var userInfo = await _db.Users.Where(c => c.Id == userId).ProjectTo<UserInfoVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (userInfo == null)
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string>
                    {
                        "an error occured"
                    }
                });

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = userInfo
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile([FromForm] UserInfoVM profile, [FromForm] IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(userId))
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                    {
                        "an error occured"
                    }
                    });

                var applicationUser = await _userManager.FindByIdAsync(userId);
                if (applicationUser == null)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "an error occured"
                        }
                    });
                try
                {
                    applicationUser.Email = profile.Email;
                    applicationUser.UserName = profile.Username;
                    applicationUser.Fname = profile.Fname;
                    applicationUser.Lname = profile.Lname;
                    applicationUser.Age = profile.Age != null ? profile.Age.Value : 0;
                    applicationUser.Gender = profile.Gender;

                    if (pictureFile != null)
                    {

                        applicationUser.Picture = await UploadPictureAndGetPath(pictureFile);
                    }

                    var result = await _userManager.UpdateAsync(applicationUser);
                    if (!result.Succeeded)
                        return Ok(new APIResponseModel
                        {
                            Status = APIStatus.Failed.ToString(),
                            Errors = new List<string>
                            {
                                "an error occured"
                            }
                        });

                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Succeeded.ToString(),

                    });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "an error occured"
                        }
                    });
                }


            }

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Failed.ToString(),
                Errors = new List<string>
                {
                    "an error occured"
                }
            });
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVM changePass)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(userId))
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "an error occured"
                        }
                    });

                var applicationUser = await _userManager.FindByIdAsync(userId);
                if (applicationUser == null)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "an error occured"
                        }
                    });
                try
                {
                    var result = await _userManager.ChangePasswordAsync(applicationUser, changePass.CurrentPassword, changePass.NewPassword);

                    if (!result.Succeeded)
                        return Ok(new APIResponseModel
                        {
                            Status = APIStatus.Failed.ToString(),
                            Errors = result.Errors.Select(c => c.Description)
                        });



                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Succeeded.ToString(),

                    });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "an error occured"
                        }
                    });
                }


            }

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Failed.ToString(),
                Errors = new List<string>
                {
                    "an error occured"
                }
            });
        }


        private async Task<string> UploadPictureAndGetPath(IFormFile pictureFile)
        {

            try
            {

                string filePath = "Uploads/Pictures";
                FileInfo fi = new FileInfo(pictureFile.FileName);

                string originalFileName = Path.GetFileName(pictureFile.FileName);
                var date = DateTime.Now.ToString("hhmmssffffff");
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
                var setFilename = "File" + date + originalFileName + fi.Extension;
                var setFilePath = Path.Combine(uploads, setFilename);

                if (pictureFile.Length > 0)
                {

                    using (var stream = new FileStream(setFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                    {
                        await pictureFile.CopyToAsync(stream);
                        await stream.DisposeAsync();
                        stream.Close();
                    }
                }
                return "/" + filePath + "/" + setFilename;



            }
            catch (Exception ex)
            {

            }
            return string.Empty;
        }

    }
}
