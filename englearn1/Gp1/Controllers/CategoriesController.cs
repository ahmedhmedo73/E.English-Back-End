using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{

    public class Categoryform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public  IFormFile? pictureFile { get; set; }


    }


    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : ControllerBase
    {

        readonly DB _db;
        readonly IMapper _mapper;
        readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(DB db, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Categoryform categoryform)
        {
            if (!ModelState.IsValid)
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = ModelState.SelectMany(s => s.Value.Errors.Select(c => c.ErrorMessage))
                });

            try
            {

                var category = new Category
                {
                    Name = categoryform.Name,
                    Description = categoryform.Description,
                    Picture = categoryform.pictureFile != null ? await UploadPictureAndGetPath(categoryform.pictureFile) : string.Empty,
                    CreationTime = DateTime.UtcNow
                };


                await _db.AddAsync(category);
                await _db.SaveChangesAsync();

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

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] Categoryform categoryform)
        {
            if (!ModelState.IsValid)
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = ModelState.SelectMany(s => s.Value.Errors.Select(c => c.ErrorMessage))
                });

            try
            {
                var categoryInDb = await _db.Categories.Where(s => s.Id == categoryform.Id).FirstOrDefaultAsync();

                if (categoryInDb == null)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "category is not found"
                        }
                    });


                categoryInDb.Name = categoryform.Name;
                categoryInDb.Description = categoryform.Description;

                if (categoryform.pictureFile != null)
                    categoryInDb.Picture = await UploadPictureAndGetPath(categoryform.pictureFile);


                await _db.SaveChangesAsync();

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

        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            try
            {

                var categoryInDb = await _db.Categories
                    .Include("Videos")
                    .Include("Videos.Questions")
                    .Include("Videos.Questions.Answers")
                    .Include("Videos.Questions.UsersAnswers")
                    .Include("Videos.SpokenSentences")
                    .Include("Videos.SpokenSentences.UsersAnswers")
                    .Include("Videos.Comments")
                    .Include("Videos.Views")
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (categoryInDb == null)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "category is not found"
                        }
                    });


                _db.Remove(categoryInDb);
                await _db.SaveChangesAsync();
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
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = await _db.Categories.ToListAsync()
            });

        }


        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = await _db.Categories.FirstOrDefaultAsync(s => s.Id == id)
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
