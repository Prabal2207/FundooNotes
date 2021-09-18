using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        private  NotesRL _notesRL;

        public NotesBL(NotesRL notesRL)
        {
            this._notesRL = notesRL;
        }

        public List<Notes> getAllData()
        {
            try
            {
                return this._notesRL.getAllData();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool AddData(NotesModel notesModel, long userId)
        {
            try
            {
                return this._notesRL.AddData(notesModel, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }




        public bool DeleteNotes(long id, long userId)
        {
            try
            {
                return this._notesRL.DeleteNotes(id, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {
            try
            {
                return this._notesRL.UpdateNotes(id, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool isPin(long id, long userId, bool value)
        {

            try
            {
                return this._notesRL.isPin(id, userId, value);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool ChangeColor(long id, long userId, NotesModel notesModel)
        {

            try
            {
                return this._notesRL.ChangeColor(id, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
