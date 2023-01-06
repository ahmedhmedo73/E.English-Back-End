using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gp1.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Gp1.Controllers
{
    public class Sentenceform
    {
        public string Sentence { get; set; }
        public int Vid { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class SentenceController : ControllerBase
    {
        private DB _db;
        private IMapper _mapper;
        public SentenceController(DB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SetSentence([FromBody] Sentenceform sentenceform)
        {
            try
            {
                SpokenSentence spokenSentence = new SpokenSentence();
                spokenSentence.Sentence = sentenceform.Sentence;
                spokenSentence.VideoId = sentenceform.Vid;
                spokenSentence.CreationTime = DateTime.UtcNow;
                _db.spokenSentences.Add(spokenSentence);
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
                    "error occured"
                }
            });

        }

        [HttpGet]
        public IActionResult GetSentence(int? id)
        {
            if (id == null)
                return NotFound();

            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.spokenSentences.Find(id.Value)

            });

        }

        [HttpGet]
        public IActionResult GetAllSentences()
        {
            return Ok(new APIResponseModel
            {
                Status = APIStatus.Succeeded.ToString(),
                Data = _db.spokenSentences.ToList()

            });

        }

        [HttpGet]
        public IActionResult GetSentences(int? id)
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
                Data = _db.spokenSentences.Where(c => c.VideoId == id).ToList()
            });

        }

        [HttpDelete]
        public IActionResult DeleteSentence(int? id)
        {
            if (id == null)
                return NotFound();
            try
            {
                SpokenSentence ss = _db.spokenSentences.Include("UsersAnswers").FirstOrDefault(s => s.Id == id);
                if (ss != null)
                {
                    _db.spokenSentences.Remove(ss);
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
                    "error occured"
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetSentenceDetails(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {

                var questionDetails = await _db.spokenSentences.Where(s => s.Id == id).ProjectTo<SentenceDetails>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
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
