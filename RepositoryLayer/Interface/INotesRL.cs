using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    interface INotesRL
    {
        List<Notes> getAllData();

        bool AddData(NotesModel notesModel, long userId);

        

        bool DeleteNotes(long id, long userId);

        bool UpdateNotes(long id, long userId, NotesModel notesModel);

        bool isPin(long id, long userId, bool value);

        bool ChangeColor(long id, long userId, NotesModel notesModel);
    }
}
