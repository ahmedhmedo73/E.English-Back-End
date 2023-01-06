using Gp1.model;using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;namespace Gp1.Controllers{    public class commentform    {        public int IdVid { get; set; }        public string strcoment { get; set; }    }    [Route("[controller]/[action]")]    [ApiController]    [Authorize(Roles = "User")]
    public class CommentController : ControllerBase    {        private DB _db;        private UserManager<ApplicationUser> _userManager;        public CommentController(DB db, UserManager<ApplicationUser> userManager)        {            _db = db;
            _userManager = userManager;
        }
        [HttpPost]        public IActionResult PutComment(commentform commentform)        {
            try
            {
                var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();


                comment comment = new comment
                {
                    CreationTime = DateTime.UtcNow,
                    UserId = userId,
                    VideoId = commentform.IdVid,
                    comm = commentform.strcoment
                };

                _db.comments.Add(comment);
                _db.SaveChanges();
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                });
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
        }        [HttpDelete]        public IActionResult deletecomm(int id)        {

            try
            {
                comment comment = _db.comments.Find(id);
                _db.comments.Remove(comment);
                _db.SaveChanges();
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                });
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
            });        }    }}