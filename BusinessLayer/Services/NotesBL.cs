using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        private INotesRL _notesRL;

        public NotesBL(INotesRL notesRL)
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

        public bool AddData(NotesModel notesModel, long NotesId)
        {
            try
            {
                return this._notesRL.AddData(notesModel, NotesId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notes> GetAllNotes(long userId)
        {
            try
            {
                return this._notesRL.GetAllNotes(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }




        public bool DeleteNotes(long userId, long NotesId)
        {
            try
            {
                return this._notesRL.DeleteNotes(userId, NotesId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RestoreNotes(long noteId, long userId)
        {
            try
            {
                return this._notesRL.RestoreNotes(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNotes(long userId, long NotesId, NotesModel notesModel)
        {
            try
            {
                return this._notesRL.UpdateNotes(userId, NotesId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool isPin(long userId, long NotesId, bool value)
        {

            try
            {
                return this._notesRL.isPin(userId, NotesId, value);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool ChangeColor(long userId, long NotesId, NotesModel notesModel)
        {

            try
            {
                return this._notesRL.ChangeColor(userId, NotesId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }

        }

       public bool IsArchive(long userId, long NotesId, bool value)
       {
            try
            {
                return this._notesRL.IsArchive(userId, NotesId, value);
            }
            catch (Exception)
            {
                throw;
            }

       }

       public bool UnArchive(long noteId, long userId)
        {
            try
            {
                return this._notesRL.UnArchive(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public List<Notes> GetArchiveNotes(long userId)
        {
            try
            {
                return this._notesRL.GetArchiveNotes(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTrash(long userId, long NotesId, bool value)
        {
            try
            {
                return this._notesRL.IsTrash(userId, NotesId, value);
            }
            catch (Exception)
            {
                throw;
            }

        }

       public List<Notes> GetTrash(long userId)
        {
            try
            {
                return this._notesRL.GetTrash(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteForever(long noteId, long userId)
        {
            try
            {
                return this._notesRL.DeleteForever(noteId,userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

      public bool EmptyTrash(long userId)
        {
            try
            {
                return this._notesRL.EmptyTrash(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
