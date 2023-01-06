using Gp1.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{
    public class viewform
    {
        public int IdVideo { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        private DB _db;
        private UserManager<ApplicationUser> _userManager;
        public ViewsController(DB db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [HttpPost]
        public IActionResult AddView([FromForm] viewform viewform)
        {
            try
            {

                var userId = User.Claims.Where(s=>s.Type == "uid").Select(c=>c.Value).FirstOrDefault();

                var video = _db.videos.Where(s => s.id == viewform.IdVideo).FirstOrDefault();
                if (video != null)
                {
                    video.viewsCount++;
                    _db.SaveChanges();
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
                    "an error occured"
                }
            });

        }


        [HttpGet]
        public IActionResult GetViewsInvid(int idvid)
        {

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.Views.Include("User").Where(m => m.Video.id == idvid).ToList()
            });
            
        }



        [HttpGet]
        public IActionResult Count_Views_In_Vid(int idvid)
        {
           
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.Views.Count(m => m.VideoId == idvid)
            });
            
        }


        [HttpGet]
        public IActionResult Get_Views_with_user()
        {
            var userId = User.Claims.Where(s=>s.Type == "uid").Select(c=>c.Value).FirstOrDefault();

         
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.Views.Include("Video").Where(m => m.UserId == userId).ToList()
            });
        }

        [HttpGet]
        public IActionResult Count_Vid_Watched_by_User()
        {
            var userId = User.Claims.Where(s=>s.Type == "uid").Select(c=>c.Value).FirstOrDefault();
 
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.Views.Include("Video").Where(m => m.UserId == userId).ToList()
            });
        
        }

    }
}
