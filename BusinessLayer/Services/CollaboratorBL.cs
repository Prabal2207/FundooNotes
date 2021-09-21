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
    public class CollaboratorBL:ICollaboratorBL
    {
        private ICollaboratorRL _collaboratorRL;

        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this._collaboratorRL = collaboratorRL;
        }

      

        public bool AddCollaborator(string collaboratorEmailId, long noteid, long userId)
        {
            try
            {
                return this._collaboratorRL.AddCollaborator(collaboratorEmailId, noteid, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Collaborator> GetCollab(long noteId, long userId)
        {
            try
            {
                return this._collaboratorRL.GetCollab(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public bool RemoveCollab(long noteId, long userId, string collabEmail)
        {
            try
            {
                return this._collaboratorRL.RemoveCollab(noteId, userId, collabEmail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
