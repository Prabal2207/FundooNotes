
using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private ICollaboratorBL _collaboratorBL;


        public CollaboratorController(ICollaboratorBL collaboratorBL, IConfiguration configuration)
        {
            this._collaboratorBL = collaboratorBL;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }
        [HttpPost]
        public IActionResult AddCollaborator(CollaboraterModel collaboratorModel,long noteid)
        {
            try
            {
                long userId = getTokenID();
                bool result = this._collaboratorBL.AddCollaborator(collaboratorModel.CollaboratorEmailId, noteid, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Data Added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Data addition failed!!" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpGet]
        [Route("noteId/GetCollaborations")]
        public IActionResult GetCollab(long noteId)
        {
            try
            {
                long userId = getTokenID();
                var collabList = _collaboratorBL.GetCollab(noteId, userId);

                if (collabList.Count != 0)
                {
                    return Ok(new { success = true, message = "These are the Collaborations of these note.", data = collabList });
                }
                else if (collabList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "No collaboration found." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Something went wrong." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("noteId/RemoveCollaboration")]
        public IActionResult RemoveCollab(long noteId, CollaboraterModel collaboratorModel)
        {
            try
            {
                long userId = getTokenID();
                var result = _collaboratorBL.RemoveCollab(noteId, userId, collaboratorModel.CollaboratorEmailId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Collaboration Removed Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Removing Collaboration failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

    }
}
