using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    public class qufrom 
    {
         public int idqu {get; set;}
         public int numberqu {get; set;}
    }


    [Route("[controller]/[action]")]
    [ApiController]
    public class TestQuController : ControllerBase
    {
        private DB _db;
        public TestQuController(DB db)
        {
            _db = db;
        }
        //[HttpPost]
        //public bool GetTest(List<qufrom> qufroms)
        //{
        //}
    }
}
