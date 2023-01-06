using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlayVideoController : ControllerBase
    {
        private DB _db;

        public PlayVideoController(DB db)
        {
            _db = db;
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public FileResult PlayVideo(int? id)
        //{
        //    string path = @"C:\Users\abdo\source\repos\Gp1\Gp1";
        //    Video vid = DB.videos.Find(Convert.ToInt32(id));
        //    path = path + vid.Link_Vid;
        //    return PhysicalFile(path, contentType: "application/octet-stream", enableRangeProcessing: true);
        //}



        //[HttpGet]
        //public IActionResult GetNextVideo(int? IdUser)
        //{
        //    string StoredProc = "EXEC nextvideo " + IdUser.ToString();
        //    return DB.videos.FromSql(StoredProc);
        //}
    }
}
