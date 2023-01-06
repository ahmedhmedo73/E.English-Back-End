using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class VidUserController : ControllerBase
    {
        private DB _db;
        public VidUserController(DB db)
        {
            _db = db;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetVideo(int? id)
        // {
        //     if (id == null)
        //         return NotFound();

        //     var video = _db.videos.Include("Questions")
        //                      .Include("Questions.Answers")
        //                      .Include("SpokenSentences")
        //                      .Include("Comments")
        //                      .FirstOrDefault(c => c.id == id);

        //     if (video == null)
        //         return NotFound();

        //     var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();

        //     if (string.IsNullOrWhiteSpace(userId))
        //         return NotFound();

        //     try
        //     {
        //         var user = await _db.Users.FirstOrDefaultAsync(c => c.Id == userId);
        //         if (user != null)
        //         {
        //             user.CurrentVideoId = video.id;
        //             user.CurrentCategoryId = video.CategoryId;
        //             await _db.SaveChangesAsync();

        //             var prevVideoId = await _db.videos.Where(c=> c.CategoryId == video.CategoryId && c.id < id)
        //                 .OrderBy(c=>c.id)
        //                 .Select(c=>c.id)
        //                 .FirstOrDefaultAsync();

        //             var nextVideoId = await _db.videos.Where(c=> c.CategoryId == video.CategoryId && c.id > id)
        //                 .OrderBy(c => c.id)
        //                 .Select(c=>c.id)
        //                 .FirstOrDefaultAsync();

        //             return Ok(new APIResponseModel
        //             {
        //                 Status = APIStatus.Succeeded.ToString(),
        //                 Data = new
        //                 {
        //                     prevVideo = prevVideoId,
        //                     currentVideo = video,
        //                     nextVideo = nextVideoId,
        //                 }
        //             });
        //         }

        //     }
        //     catch (Exception ex)
        //     {
        //     }
        //     return Ok(new APIResponseModel
        //     {
        //         Status = APIStatus.Failed.ToString(),
        //         Errors = new List<string> { "an error occured" }
        //     });

        // }

        [HttpGet]
        public IActionResult GetVideo(string? CategoryName, string? videoName)
        {
            var category = _db.Categories.FirstOrDefault(m => m.Name == CategoryName);

            if (category != null)
            {
                 return Ok(new APIResponseModel
                  {
                    Status = APIStatus.Succeeded.ToString(),
                    Data= _db.videos.Include("Questions")
                            .Include("Questions.Answers")
                            .Include("SpokenSentences")
                            .Include("Comments")
                            .FirstOrDefault(c => c.Name == videoName && c.CategoryId == category.Id)
                  });
            }
            else
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string> { "category is not found" }
                });
            }
            
        }



        [HttpGet]
        public IActionResult GetVideosByCategoryName(string? categoryName)
        {

            var category = _db.Categories.FirstOrDefault(m => m.Name == categoryName);

            if (category != null)
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                    Data = _db.videos.Where(s => s.CategoryId == category.Id)
                });

            }
            else
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string> { "category is not found" }
                });
            }



        }



        //[HttpGet]
        //public async Task<IActionResult> GetCurrentVideo(int categoryId)
        //{

        //    var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();

        //    if (string.IsNullOrWhiteSpace(userId))
        //        return NotFound();

        //    try
        //    {
        //        var user = await _db.Users.FirstOrDefaultAsync(c => c.Id == userId);
        //        if (user != null && user.CurrentVideoId != null)
        //        {

        //            var video = _db.videos.Include("Questions")
        //                             .Include("Questions.Answers")
        //                             .Include("SpokenSentences")
        //                             .Include("Comments")
        //                             .FirstOrDefault(c => c.id == user.CurrentVideoId);
        //            return Ok(new APIResponseModel
        //            {
        //                Status = APIStatus.Succeeded.ToString(),
        //                Data = video
        //            });
        //        }
        //        else
        //        {
        //            // first or default
        //        }
               

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return Ok(new APIResponseModel
        //    {
        //        Status = APIStatus.Failed.ToString(),
        //        Errors = new List<string> { "an error occured" }
        //    });

        //}



    }
}
