using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private DB _db;
        public SectionController(DB db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GitVideo(int categoryId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.videos.Where(m => m.CategoryId == categoryId).ToList()

            });

        }
    }
}