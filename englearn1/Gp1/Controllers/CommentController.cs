﻿using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

            _userManager = userManager;
        }
        [HttpPost]
            try
            {
                var userId = User.Claims.Where(s => s.Type == "uid").Select(c => c.Value).FirstOrDefault();


                comment comment = new comment
                {
                    CreationTime = DateTime.UtcNow,
                    UserId = userId,
                    VideoId = commentform.IdVid,
                    comm = commentform.strcoment
                };

                _db.comments.Add(comment);
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


            try
            {
                comment comment = _db.comments.Find(id);
                _db.comments.Remove(comment);
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