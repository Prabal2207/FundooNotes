using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class NoteController : ControllerBase
    {
        private INotesBL _notesBL;


        public NoteController(INotesBL notesBL, IConfiguration configuration)
        {
            this._notesBL = notesBL;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
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

        [HttpGet]
        public IActionResult GetNotes()
        {
            try
            {
                long userId = getTokenID();
                var NotesList = _notesBL.GetAllNotes(userId);

                if (NotesList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are Your all the notes.", Data = NotesList });
                }
                else if (NotesList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "Nothing is added in notes." });
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

        [HttpDelete("{id:long}")]
       
        public IActionResult DeleteNotes(long Notesid)
        {
            try
            {
                long userId = getTokenID();
                var result = this._notesBL.DeleteNotes(Notesid, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Deleted SuccessFully.", Notesid });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new{ success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpPut]
        [Route("noteId/Restore")]
        public IActionResult Restorenotes(long Notesid)
        {
            try
            {
                long userId = getTokenID();
                bool result = _notesBL.RestoreNotes(Notesid, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note restored from trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [HttpPut]
        [Route("noteId/Update")]
        public IActionResult UpdateNotes(long Notesid, NotesModel notesModel)
        {
            try
            {
                var userId = getTokenID();
                var result = this._notesBL.UpdateNotes(Notesid, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Updated SuccessFully.", Notesid });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note updation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new {success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpPut]
        [Route("noteId/Pin")]
        public IActionResult isPin(long Notesid, bool value)
        {
            long userId = getTokenID();
            bool result = _notesBL.isPin(Notesid, userId, value);

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

        [HttpPut]
        [Route("noteId/ChangeColour")]
        public IActionResult ChangeColor(long Notesid, NotesModel notesModel)
        {
            long userId = getTokenID();
            bool result = _notesBL.ChangeColor(Notesid, userId, notesModel);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Color changed Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Color not changed !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [HttpPut]
        [Route("noteId/Archive")]

        public IActionResult IsArchive(long Notesid, bool value)
        {

            try
            {
                var userId = getTokenID();
                var result = this._notesBL.IsArchive(Notesid, userId, value);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Archived." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Archive remain same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpPut]
        [Route("noteId/Unarchive")]
        public IActionResult Unarchive(long Notesid)
        {
            long userId = getTokenID();
            bool result = _notesBL.UnArchive(Notesid, userId);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note Unarchived Successfully." });
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

        [HttpGet]
        [Route("Archived")]
        public IActionResult GetArchived()
        {
            try
            {
                long userId = getTokenID();
                var archivedList = _notesBL.GetArchiveNotes(userId);

                if (archivedList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are your Archived Notes.", Data = archivedList });
                }
                else if (archivedList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "There are no Archived notes." });
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
        [HttpPut]
        [Route("noteId/Trash")]

        public IActionResult IsTrash(long Notesid, bool value)
        {
            try
            {
                var userId = getTokenID();
                var result = this._notesBL.IsTrash(Notesid, userId, value);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "note added into trash." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "note remain same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new{success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }


        [HttpGet]
        [Route("Trashed")]
        public IActionResult GetTrash()
        {
            try
            {
                long userId = getTokenID();
                var trashList = _notesBL.GetTrash(userId);

                if (trashList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are your Trashed Notes.", Data = trashList });
                }
                else if (trashList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "There are no trashed notes." });
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
        [Route("noteId/DeleteForever")]
        public IActionResult DeleteForever(long noteId)
        {
            try
            {
                long userId = getTokenID();
                bool result = _notesBL.DeleteForever(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Deleted forever from trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("EmptyTrash")]
        public IActionResult EmptyTrash()
        {
            try
            {
                long userId = getTokenID();
                bool result = _notesBL.EmptyTrash(userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Deleted all trashed notes Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

    }
}
