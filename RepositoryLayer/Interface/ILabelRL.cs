using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface ILabelRL
    {
        bool AddLabeltoNotes(LabelModel labelmodel, long Noteid, long userid);

        bool AddLabeltoUser(LabelModel labelmodel, long userid);

        bool EditLabel(LabelModel labelmodel);

        bool DeleteLabel(long Labelid, long userid);

        bool RemoveLabel(long Labelid, long userid, long noteid);

        List<Label> GetNoteLables(long noteId, long userId);

        List<Label> GetUserLabels(long userId);


    }
}
