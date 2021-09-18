using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INotesBL _notesBL;
        // private IConfiguration _config;

        public NoteController(INotesBL notesBL, IConfiguration configuration)
        {
            this._notesBL = notesBL;
            // _config = configuration;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }
        [HttpGet]

        public IActionResult getAllData()
        {
            var useList = this._notesBL.getAllData();
            return this.Ok(new { Success = true, message = "Get User Data SuccessFully.", Data = useList });
        }

        [HttpPost]
        public IActionResult AddData(NotesModel notesModel)
        {
            try
            {
                long userId = getTokenID();
                bool result = this._notesBL.AddData(notesModel, userId);

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

        [HttpDelete("{id:long}")]
       
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long userId = getTokenID();
                var result = this._notesBL.DeleteNotes(id, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Deleted SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut("{id:long}")]
       
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = getTokenID();
                var result = this._notesBL.UpdateNotes(id, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Updated SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note updation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpPut("isPinned")]
        public IActionResult isPin(long noteId, bool value)
        {
            long userId = getTokenID();
            bool result = _notesBL.isPin(noteId, userId, value);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
    }
}
