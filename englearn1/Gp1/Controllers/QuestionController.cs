using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{

    public class Questionform
    {
        public int Vid { get; set; }
        public string Question { get; set; }
        public List<AnswerData> AnswerData { get; set; }
    }
    public class AnswerData
    {
        public string Answer { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class QuestionController : ControllerBase
    {

        private DB _db;
        private IMapper _mapper;
        public QuestionController(DB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult SetQuestion([FromBody] Questionform questionform)
        {
            if (!ModelState.IsValid)
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = ModelState.SelectMany(s => s.Value.Errors.Select(c => c.ErrorMessage))
                });

            try
            {
                if (questionform.AnswerData != null && questionform.AnswerData.Count != 4)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string> { "answers should be 4 answers only" }
                    });


                if (questionform.AnswerData != null && questionform.AnswerData.Count == 0)
                    return Ok(new APIResponseModel
                    {
                        Status = APIStatus.Failed.ToString(),
                        Errors = new List<string> { "answers is needed" }
                    });



                Questions question = new Questions();

                question.Question = questionform.Question;
                question.Answers = questionform.AnswerData.Select(s => new Answers
                {
                    AnswerText = s.Answer,
                    IsCorrectAnswer = s.IsCorrectAnswer,
                    CreationTime = DateTime.UtcNow,
                }).ToList();


                question.VideoId = questionform.Vid;
                question.CreationTime = DateTime.UtcNow;
                _db.questions.Add(question);
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

        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.questions.Include(s => s.Answers).ToList()
            });

        }

        [HttpGet]
        public IActionResult GetQuestions(int? id)
        {
            if (id == null)
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Failed.ToString(),
                    Errors = new List<string>() {
                        "Id can't be null here"
                    }
                }
                 );

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.questions.Include(s => s.Answers).Where(c => c.VideoId == id).ToList()
            });

        }



        [HttpDelete]
        public IActionResult deleteQuestion(int? id)
        {
            if (id == null)
                return NotFound();
            try
            {

                Questions question = _db.questions.Where(s => s.Id == id)
                    .Include("Answers")
                    .Include("UsersAnswers")
                    .FirstOrDefault();
                if (question != null)
                {

                    _db.questions.Remove(question);
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
        public async Task<IActionResult> GetQuestionsDetails(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {

                var questionDetails = await _db.questions.Where(s => s.Id == id).ProjectTo<QuestionDetails>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
                return Ok(new APIResponseModel
                {
                    Status = questionDetails != null ? APIStatus.Succeeded.ToString() : APIStatus.Failed.ToString(),
                    Data = questionDetails
                });
            }
            catch (Exception ex)
            {

            }
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Failed.ToString(),
                Data = null
            });

        }


    }
}
