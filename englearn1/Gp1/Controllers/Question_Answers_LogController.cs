using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{
    public class AnsQue
    {
        public int IdQue { get; set; }
        public int AnswerId { get; set; }
        // public string CorrectAns { get; set; }
        //public string UserAns { get; set; }
        //public int iscorrect { get; set; }
    }


    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]

    public class Question_Answers_LogController : ControllerBase
    {
        private DB _db;
        private UserManager<ApplicationUser> _userManager;
        public Question_Answers_LogController(DB db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AnsQuePost([FromBody] AnsQue AnsQue)
        {
            var userId = User.Claims.Where(s=>s.Type == "uid").Select(c=>c.Value).FirstOrDefault();


            if (string.IsNullOrWhiteSpace(userId))
            {
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string> { "your id user is not Exist" }
                });
            }


            try
            {
                var correctAnswerIdInDb = await _db.Answers.Where(s => s.QuestionId == AnsQue.IdQue && s.IsCorrectAnswer).Select(s => s.Id).FirstOrDefaultAsync();
                if (correctAnswerIdInDb == 0)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string> { "answer not found in db" }
                    });
                //// check for user answer
                UsersAnswers questionAnswers = new UsersAnswers
                {
                    QuestionId = AnsQue.IdQue,
                    AnswerId = AnsQue.AnswerId,
                    IsCorrectAnswer = AnsQue.AnswerId == correctAnswerIdInDb,
                    UserId = userId,
                    CreationTime = DateTime.UtcNow,
                };

                var answeredBefore = _db.UsersAnswers
                                        .Where( m => m.QuestionId == AnsQue.IdQue && m.IsCorrectAnswer == true)
                                        .ToList()
                                        .Count;
                if(answeredBefore == 0) { 
                    _db.UsersAnswers.Add(questionAnswers);
                    _db.SaveChanges();
                }

                // return is correct
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                    Data = new { questionAnswers.IsCorrectAnswer },
                });

            }
            catch (Exception ex)
            {

            }


            return Ok(new APIResponseModel
            {
                Status = APIStatus.Failed.ToString(),
                Errors = new List<string> { "an errror occured" }
            });
        }



    }
}
