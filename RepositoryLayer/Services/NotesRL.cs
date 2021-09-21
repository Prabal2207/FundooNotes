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
                notes.UserId = userId;

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

        public List<Notes> GetAllNotes(long userId)
        {
            try
            {
                var result = _userContext.Note.Where(e => e.UserId == userId
                                                         && e.IsArchive == false
                                                         && e.IsTrash == false).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotes(long userId, long Noteid)
        {
            var result = _userContext.Note.FirstOrDefault(e => e.UserId == userId && e.NotesId == Noteid);



            if (result != null)
            {

                _userContext.Note.Remove(result);
                _userContext.SaveChanges();

                return true;
            }

            return false;

        }

        public bool RestoreNotes(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.NotesId == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.IsTrash = false;
                    result.IsArchive = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0) { return true; }

                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool UpdateNotes(long userId, long Noteid, NotesModel notesModel)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.UserId == userId && e.NotesId == Noteid);

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


        public bool isPin(long userId, long Noteid, bool value)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.UserId == userId && e.NotesId == Noteid);

                if (result != null)
                {
                    if (result.isPin == true)
                    {
                        result.isPin = false;
                    }
                    if (result.isPin == false)
                    {
                        result.isPin = true;
                    }

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

        public bool ChangeColor(long userId, long Noteid, NotesModel notesModel)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.UserId == userId && e.NotesId == Noteid);

                if (result != null)
                {
                    result.Color = notesModel.Color;
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

        public bool IsArchive(long userId, long Noteid, bool value)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.UserId == userId && e.NotesId == Noteid);

                if (result != null)
                {
                    result.IsTrash = false;
                    result.IsArchive = true;
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

        public bool UnArchive(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.NotesId == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.IsArchive = false;
                    result.IsTrash = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0) return true;

                else return false;
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
                List<Notes> getArchiveNotes = _userContext.Note.Where(x => x.UserId == userId && (x.IsTrash == false && x.IsArchive == true)).ToList();
                return getArchiveNotes;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public bool IsTrash(long userId, long Noteid, bool value)
        {
            try
            {
                var result = _userContext.Note.FirstOrDefault(e => e.UserId == userId && e.NotesId == Noteid);
                if (result != null)
                {
                    result.IsTrash = true;
                    result.IsArchive = false;
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

        public List<Notes> GetTrash(long userId)
        {
            try
            {
                var result = _userContext.Note.Where(e => e.UserId == userId && e.IsTrash == true).ToList();

                return result;
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
                var result = _userContext.Note.FirstOrDefault(note => note.IsTrash == true
                                                                    && note.UserId == userId
                                                                    && note.NotesId == noteId);

                if (result != null)
                {
                    _userContext.Note.Remove(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else { return false; }
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
                var result = _userContext.Note.Where(e => e.IsTrash == true && e.UserId == userId).ToList();

                if (result.Count > 0)
                {
                    _userContext.Note.RemoveRange(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
