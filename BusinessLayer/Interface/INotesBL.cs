using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
   public interface INotesBL
    {
        List<Notes> getAllData();
        

        bool DeleteNotes(long id, long userId);

        bool UpdateNotes(long id, long userId, NotesModel notesModel);

        bool AddData(NotesModel notesModel, long userId);

        bool isPin(long id, long userId, bool value);

        bool ChangeColor(long id, long userId, NotesModel notesModel);
    }
}
