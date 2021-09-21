using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollaboratorBL
    {
       
        bool AddCollaborator(string collaboratorEmailId, long noteid, long userId);

        List<Collaborator> GetCollab(long noteId, long userId);

        bool RemoveCollab(long noteId, long userId, string collabEmail);
    }
}
