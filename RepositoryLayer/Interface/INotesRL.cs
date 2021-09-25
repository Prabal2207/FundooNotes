using CommonLayer;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        List<Notes> getAllData();

        bool AddData(NotesModel notesModel, long NotesId);

        List<Notes> GetAllNotes(long userId, string userEmail);

        bool DeleteNotes(long UserId, long NotesId);

        bool RestoreNotes(long noteId, long userId);

        bool UpdateNotes(long UserId, long NotesId, NotesModel notesModel);

        bool isPin(long UserId, long NotesId, bool value);

        bool ChangeColor(long UserId, long NotesId, NotesModel notesModel);

        bool AddImage(long noteId, IFormFile imageProps);

        bool DeleteImage(long noteId, long userId);

        bool IsArchive(long UserId, long NotesId, bool value);

        bool UnArchive(long noteId, long userId);

        List<Notes> GetArchiveNotes(long userId);

        bool IsTrash(long UserId, long NotesId, bool value);

        List<Notes> GetTrash(long userId);

        bool DeleteForever(long noteId, long userId);

        bool EmptyTrash(long userId);

        bool AddReminder(long noteId, long userId, DateTime dateTime);

        bool DeleteReminder(long noteId, long userId);

        bool ChangeReminder(long noteId, long userId, DateTime dateTime);


    }
}
