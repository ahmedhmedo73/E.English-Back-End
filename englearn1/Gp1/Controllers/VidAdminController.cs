using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gp1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Gp1.Controllers
{
    public class VideoForm
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class VidAdminController : ControllerBase
    {
        private DB _db;

        private readonly IWebHostEnvironment webHostEnv;
        readonly IWebHostEnvironment _webHostEnvironment;

        public VidAdminController(DB db, IWebHostEnvironment webHostEnvironment, IWebHostEnvironment webHostEnvironment1)
        {
            webHostEnv = webHostEnvironment;
            _webHostEnvironment = webHostEnvironment1;
            _db = db;
        }

        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public IActionResult uploadvideo([FromForm] IList<IFormFile> files, [FromForm] VideoForm videoForm)
        {
            if (files == null)
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string>
                    {
                        "bad"
                    }
                });
            }
            try
            {
                foreach (var file in files)
                {
                    string Pathvid = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Videos");
                    Video vid;
                    string filepath = Path.Combine(Pathvid, file.FileName);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    vid = new Video();
                    vid.Name = videoForm.Name;
                    vid.CategoryId = videoForm.CategoryId;
                    vid.Link_Vid = "Uploads/Videos" + file.FileName;
                    vid.CreationTime = DateTime.UtcNow;
                    _db.videos.Add(vid);
                    _db.SaveChanges();
                }
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
                    "bad"
                }
            });

        }

        [HttpGet]
        public IActionResult GetAllVideos()
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.videos.ToList()
            });

        }

        [HttpGet]
        public IActionResult GetVideo(int? id)
        {
            int idint = Convert.ToInt32(id);
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.videos.Where(s => s.id == idint).Include(m => m.Questions).FirstOrDefault()
            });
        }

        [HttpDelete]
        public  IActionResult Deletevid(int? id)
        {
            if (id == null)
                return NotFound();
            try
            {

                var vid =  _db.videos
                    .Include("Questions")
                    .Include("Questions.Answers")
                    .Include("Questions.UsersAnswers")
                    .Include("SpokenSentences")
                    .Include("SpokenSentences.UsersAnswers")
                    .Include("Comments")
                    .Include("Views")
                    .FirstOrDefault(s => s.id == id);

                if (vid != null)
                {

                    _db.Remove(vid);
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

    }
}