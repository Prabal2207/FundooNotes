using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        private UserContext _notesContext;

        public NotesRL(UserContext notesContext)
        {
            this._notesContext = notesContext;
        }

        public List<NotesModel> getAllData()
        {
            try
            {
                List<NotesModel> notesModels = new List<NotesModel>();
               

                return notesModels;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
