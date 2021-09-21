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
    public class CollaboratorRL : ICollaboratorRL
    {
        private UserContext _userContext;
        Collaborator collaborator = new Collaborator();

        public CollaboratorRL(UserContext userContext)
        {
            this._userContext = userContext;
        }
         
        //public bool AddCollaborator(CollaboraterModel collaboratorModel,long id, long userId)
        //{

        //    //var resultNote = _userContext.Note.Find(userId);
        //    //var checkmail = _userContext.Users.FirstOrDefault(e => e.Email == collaboratorModel.CollaboratorEmailId && e.Id == userId);

        //    //if (checkmail.Email == collaboratorModel.CollaboratorEmailId)
        //    //{
        //    //    if (resultNote != null)
        //    //    {
        //    //        collaborator.CollaboratorEmailId = email;
        //    //        this._userContext.Collaborator.Add(collaborator);
        //    //        _userContext.SaveChanges();

        //    //    }
        //    //    return true;
        //    //}
        //    //  return false;

        //}

        public bool AddCollaborator(string collaboratorEmailId, long noteid, long userId)
        {
            try
            {
                var resultNote = _userContext.Note.Find(noteid);
                var checkmail = _userContext.Users.FirstOrDefault(e => e.Email == collaboratorEmailId);

                if (checkmail.Email == collaboratorEmailId)
                {
                    if (resultNote != null)
                    {
                        collaborator.CollaboratorEmailId = collaboratorEmailId;
                        collaborator.UserId = userId;
                        collaborator.NotesId = noteid;
                        this._userContext.Collaborator.Add(collaborator);
                        _userContext.SaveChanges();
                        return true;

                    }
                   
                }
                return false;

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
                var result = _userContext.Collaborator.Where(e => e.NotesId == noteId && e.UserId == userId).ToList();

                return result;
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
                var result = _userContext.Collaborator.FirstOrDefault(e => e.NotesId == noteId
                                                                            && e.UserId == userId
                                                                            && e.CollaboratorEmailId == collabEmail);

                if (result != null)
                {
                    _userContext.Collaborator.Remove(result);
                    _userContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
