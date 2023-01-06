using Microsoft.AspNetCore.Mvc;
using Gp1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class MyAnswerController : ControllerBase
    {
        private DB _db;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        public MyAnswerController(DB db, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult Get_Question_Answers()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db
                 .UsersAnswers
                 .Include("Question")
                 .Where(m => m.UserId == userId)
                 .ToList()
            });

        }

        [HttpGet]
        public IActionResult Get_Question_Answers_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db
                 .UsersAnswers
                 .Include("Question")
                 .Where(m => m.UserId == userId)
                 .ToList()
            });

        }


        [HttpGet]
        public IActionResult Get_Question_Answers_Count()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.UsersAnswers.Where(m => m.UserId == userId).ToList().Count
            });

        }


        [HttpGet]
        public IActionResult Get_Question_Answers_Count_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.UsersAnswers.Where(m => m.UserId == userId).ToList().Count
            });

        }



        [HttpGet]
        public IActionResult Get_Question_Answers_Count_mistake()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                    UsersAnswers.
                    Where(m => m.UserId == userId && !m.IsCorrectAnswer).
                    ToList().
                    Count
            });

        }


        [HttpGet]
        public IActionResult Get_Question_Answers_Count_mistake_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                    UsersAnswers.
                    Where(m => m.UserId == userId && !m.IsCorrectAnswer).
                    ToList().
                    Count
            });

        }


        [HttpGet]
        public IActionResult Get_Question_Answers_Count_Right()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                   UsersAnswers.
                   Where(m => m.UserId == userId && m.IsCorrectAnswer).
                   ToList().
                   Count
            });

        }

        [HttpGet]
        public IActionResult Get_Question_Answers_Count_Right_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                   UsersAnswers.
                   Where(m => m.UserId == userId && m.IsCorrectAnswer).
                   ToList().
                   Count
            });

        }


        [HttpGet]
        public IActionResult Get_Sentence_Answers()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                   SentenceUsersAnswers.
                   Include(s => s.Sentence).
                   Where(m => m.UserId == userId).
                   ToList()
            });

        }


        [HttpGet]
        public IActionResult Get_Sentence_Answers_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                   SentenceUsersAnswers.
                   Include(s => s.Sentence)
                   .Where(m => m.UserId == userId).
                   ToList()
            });

        }



        [HttpGet]
        public IActionResult Get_Sentence_Answers_count()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                    SentenceUsersAnswers.
                   Include(s => s.Sentence).
                   Where(m => m.UserId == userId).
                   ToList().Count
            });

        }


        [HttpGet]
        public IActionResult Get_Sentence_Answers_count_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                   SentenceUsersAnswers.
                   Include(s => s.Sentence).
                   Where(m => m.UserId == userId).
                   ToList().Count
            });

        }


        [HttpGet]
        public IActionResult Get_Sentence_Answers_count_mistake()
        {
            var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.
                 SentenceUsersAnswers
                .Where(m => m.UserId == userId).ToList().Count
            });

        }


        [HttpGet]
        public IActionResult Get_Sentence_Answers_count_mistake_By_Admin(string userId)
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.SentenceUsersAnswers.Where(m => m.UserId == userId).ToList().Count
            });


        }

        [HttpGet]
        public async Task<IActionResult> GetUserAnswersOnQuestions(string userId)
        {
            var userQusetionsReport = await _db.Users.Where(s => s.Id == userId)
                .ProjectTo<UserAnswersForQusetions>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = userQusetionsReport
            });


        }

        [HttpGet]
        public async Task<IActionResult> GetUserAnswersOnSentences(string userId)
        {
            var userQusetionsReport = await _db.Users.Where(s => s.Id == userId)
                .ProjectTo<UserAnswersForSentences>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = userQusetionsReport
            });


        }
    }
}