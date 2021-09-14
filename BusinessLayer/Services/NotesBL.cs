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

        public List<NotesModel> getAllData()
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
    }
}
