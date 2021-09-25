using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private ILabelBL _labelBL;


        public LabelController(ILabelBL labelBL)
        {
            this._labelBL = labelBL;
        }

        private long getTokenID()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpPost]
        [Route("{NotesId:long}")]

        public IActionResult AddLabeltoNotes(LabelModel labelmodel, long NotesId)
        {
            try
            {
                long Userid = getTokenID();
                bool result = this._labelBL.AddLabeltoNotes(labelmodel, NotesId, Userid);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Label Added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label addition failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        
        }


        [HttpPost]
       

        public IActionResult AddLabeltuUser(LabelModel labelmodel)
        {
            try
            {
                long Userid = getTokenID();
                bool result = this._labelBL.AddLabeltoUser(labelmodel, Userid);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Label Added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label addition failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }
        [HttpPut]
        [Route("EditLabel")]
        public IActionResult Editlabel(LabelModel labelmodel)
        {
            try
            {
                
                bool result = this._labelBL.EditLabel(labelmodel);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Label Edited Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label Editing failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpDelete]
        [Route("{LabelId:long}")]
        public IActionResult Delete(long LabelId)
        {
            try
            {
                long Userid = getTokenID();
                bool result = this._labelBL.DeleteLabel(LabelId, Userid);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Label Deleted Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label Deletion failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpDelete]
        

        public IActionResult Remove(long LabelId,long NotesId)
        {
            try
            {
                long Userid = getTokenID();
                bool result = this._labelBL.RemoveLabel(LabelId, Userid, NotesId);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Label Added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label addition failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpGet]
        [Route("{NotesId:long}")]
        public IActionResult GetLabelNotes(long NotesId)
        {
            try
            {
                long Userid = getTokenID();
                var Labellist = this._labelBL.GetNoteLables(Userid, NotesId);
                if (Labellist.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "Label Added Successfully!" });
                }
                else if (Labellist.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "Nothing is added in Labels." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label addition failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpGet]
      

        public IActionResult GetLabelUser()
        {
            try
            {
                long Userid = getTokenID();
                var Labellist = this._labelBL.GetUserLabels(Userid);
                if (Labellist.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "Label Added Successfully!" });
                }
                else if (Labellist.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "Nothing is added in Labels." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Label addition failed!!" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }
    }
}
