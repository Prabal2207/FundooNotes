using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelBL: ILabelBL
    {
        private ILabelRL _labelRL;

        public LabelBL(ILabelRL labelRL)
        {
            this._labelRL = labelRL;
        }

        public bool AddLabeltoNotes(LabelModel labelmodel, long Noteid, long userid)
        {
            try
            {
                return this._labelRL.AddLabeltoNotes(labelmodel, Noteid, userid);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public bool AddLabeltoUser(LabelModel labelmodel, long userid)
        {
            try
            {
                return this._labelRL.AddLabeltoUser(labelmodel, userid);
            }
            catch (Exception)
            {
                throw;
            }
        }

       

       public bool EditLabel(LabelModel labelmodel)
        {
            try
            {
                return this._labelRL.EditLabel(labelmodel);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public bool DeleteLabel(long Labelid, long userid)
        {
            try
            {
                return this._labelRL.DeleteLabel(Labelid, userid);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public bool RemoveLabel(long Labelid, long userid, long noteid)
        {
            try
            {
                return this._labelRL.RemoveLabel(Labelid, userid, noteid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Label> GetNoteLables(long noteId, long userId)
        {
            try
            {
                return this._labelRL.GetNoteLables(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public List<Label> GetUserLabels(long userId)
        {
            try
            {
                return this._labelRL.GetUserLabels(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
