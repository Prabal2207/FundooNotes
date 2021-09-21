using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollaboratorRL
    {
        bool AddCollaborator(string collaboratorEmailId, long noteid, long userId);

        List<Collaborator> GetCollab(long noteId, long userId);

        bool RemoveCollab(long noteId, long userId, string collabEmail);
    }
}
