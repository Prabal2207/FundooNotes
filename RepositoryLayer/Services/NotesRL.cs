using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        private UserContext _userContext;

        public NotesRL(UserContext userContext)
        {
            this._userContext = userContext;
        }

        public List<Notes> getAllData()
        {
            try
            {
                var result = _userContext.Note.ToList();

                return result;
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
                Notes notes = new Notes();
                notes.Title = notesModel.Title;
                notes.Message = notesModel.Message;
                notes.Color = notesModel.Color;
                notes.image = notesModel.image;
                notes.IsArchive = notesModel.IsArchive;
                notes.IsTrash = notesModel.IsTrash;
                notes.CreatedAt = DateTime.Now;
                notes.ModifiedAt = null;
                notes.Id = userId;

                this._userContext.Note.Add(notes);
                int result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeleteNotes(long id, long userId)
        {
            var result = _userContext.Note.Find(id);



            if (result != null)
            {

                _userContext.Note.Remove(result);
                _userContext.SaveChanges();

                return true;
            }

            return false;

        }


        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.UserId == id && e.Id == userId);

                if (result != null)
                {
                    if (notesModel.Title != null)
                    {
                        result.Title = notesModel.Title;
                    }
                    if (notesModel.Message != null)
                    {
                        result.Message = notesModel.Message;
                    }

                    result.ModifiedAt = DateTime.Now;
                    _userContext.SaveChanges();

                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
