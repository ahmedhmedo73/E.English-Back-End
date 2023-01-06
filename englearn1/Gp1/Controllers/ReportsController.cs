using AutoMapper;
using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{


    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ReportsController : ControllerBase
    {

        private DB _db;
        private IMapper _mapper;
        public ReportsController(DB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetReportSummary()
        {
            try
            {

                var report = new ReportsVM
                {
                    TotalUsers = await _db.Users.CountAsync(c => !c.UserRoles.Any(c => c.Role.Name == Roles.Admin.ToString())),
                    TotalVideos = await _db.videos.CountAsync(),
                    TotalCategories = await _db.Categories.CountAsync(),
                    TotalQuestions = await _db.questions.CountAsync(),
                };

                report.RightQuestionsAnswers = await _db.questions.Where(c => c.UsersAnswers != null && c.UsersAnswers.Count(s => s.IsCorrectAnswer) > c.UsersAnswers.Count(s => !s.IsCorrectAnswer)).Take(5).Select(c => new ListItemVM
                {
                    Id = c.Id,
                    Name = c.Question
                }).ToListAsync();

                report.WrongQuestionsAnswers = await _db.questions.Where(c => c.UsersAnswers != null && c.UsersAnswers.Count(s => s.IsCorrectAnswer) < c.UsersAnswers.Count(s => !s.IsCorrectAnswer)).Take(5).Select(c => new ListItemVM
                {
                    Id = c.Id,
                    Name = c.Question
                }).ToListAsync();

                report.RightSentenceAnswers = await _db.spokenSentences.Where(c => c.UsersAnswers != null && c.UsersAnswers.Count(s => s.IsCorrectAnswer) > c.UsersAnswers.Count(s => !s.IsCorrectAnswer)).Take(5).Select(c => new ListItemVM
                {
                    Id = c.Id,
                    Name = c.Sentence
                }).ToListAsync();

                report.WrongSentenceAnswers = await _db.spokenSentences.Where(c => c.UsersAnswers != null && c.UsersAnswers.Count(s => s.IsCorrectAnswer) < c.UsersAnswers.Count(s => !s.IsCorrectAnswer)).Take(5).Select(c => new ListItemVM
                {
                    Id = c.Id,
                    Name = c.Sentence
                }).ToListAsync();

                report.RegisterUserCountPerDay = await _db.Users.Where(c => !c.UserRoles.Any(c => c.Role.Name == Roles.Admin.ToString())).GroupBy(c => c.CreationTime.Date).Select(s => new RegisterUserCountPerDay
                {
                    Day = s.Key,
                    Count = s.Count()
                }).OrderBy(c=>c.Day).ToListAsync();
                return Ok(new APIResponseModel
                {
                    Status = APIStatus.Succeeded.ToString(),
                    Data = report
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
