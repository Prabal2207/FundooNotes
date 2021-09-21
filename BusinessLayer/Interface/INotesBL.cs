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
        List<Notes> GetAllNotes(long userId);
        bool DeleteNotes(long UserId, long NotesId);

        bool RestoreNotes(long noteId, long userId);

        bool UpdateNotes(long UserId, long NotesId, NotesModel notesModel);

        bool AddData(NotesModel notesModel, long NotesId);

        bool isPin(long UserId, long NotesId, bool value);

        bool ChangeColor(long UserId, long NotesId, NotesModel notesModel);

        bool IsArchive(long UserId, long NotesId, bool value);

        bool UnArchive(long noteId, long userId);

        List<Notes> GetArchiveNotes(long userId);
        bool IsTrash(long UserId, long NotesId, bool value);

        List<Notes> GetTrash(long userId);

        bool DeleteForever(long noteId, long userId);

        bool EmptyTrash(long userId);


    }
}
