using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    public class Resultinfo
    {
        public int IdVid { get; set; }
    }


    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]

    public class ResultController : ControllerBase
    {
        private DB _db;
        private UserManager<ApplicationUser> _userManager;
        public ResultController(DB db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult AddResult(Resultinfo resultinfo)
        {
            var userId = User.Claims.Where(s=>s.Type == "uid").Select(c=>c.Value).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(userId))
            {
                

                result result = new result
                {

                    videoId = resultinfo.IdVid,
                    UserId = userId,
                    CreationTime = DateTime.UtcNow,
                };
                try
                {
                    _db.result.Add(result);
                    _db.SaveChanges();
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Succeeded.ToString(),
                        
                    });

                }
                catch (Exception ex)
                {

                }
            }
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Failed.ToString(),
                Errors =new List<string>
                {
                    "error occured"
                }
            });

        }

        [HttpGet]
        public IActionResult GetResultUser()
        {
            var userId = User.Claims.Where(s=>s.Type == "uid").Select(c=>c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.result.Count(m => m.UserId == userId)

            });
       

        }
    }
}
