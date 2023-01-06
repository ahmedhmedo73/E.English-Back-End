using Gp1.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{
    public class Senform
    {
        public int VideoId { get; set; }
        public string SentenceUserAnswer { get; set; }

    }


    [Route("[controller]/[action]")]
    [ApiController]
    public class sentence_Answers_logController : ControllerBase
    {
        readonly DB _db;

        public sentence_Answers_logController(DB db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> SentenceAnswersPost([FromBody] Senform senform)
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(userId)) return Unauthorized();

            try
            {
                var sentenceInDb = await _db.spokenSentences.Where(s => s.VideoId == senform.VideoId).FirstOrDefaultAsync();
                if (sentenceInDb == null)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string>
                        {
                            "sentence is not found"
                        }
                    });
                var sentenceUsersAnswers = new SentenceUsersAnswers
                {
                    UserAnswer = senform.SentenceUserAnswer,
                    SentenceId = sentenceInDb.Id,
                    IsCorrectAnswer = sentenceInDb.Sentence.ToLower() == senform.SentenceUserAnswer.ToLower(),
                    UserId = userId,
                    CreationTime = DateTime.UtcNow,

                };

                await _db.AddAsync(sentenceUsersAnswers);
                await _db.SaveChangesAsync();

                // return is correct
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                    Data = new { sentenceUsersAnswers.IsCorrectAnswer },
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
    }
}
