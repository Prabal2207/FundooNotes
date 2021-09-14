using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;

namespace BusinessLayer.Interface
{
   public interface INotesBL
    {
        List<NotesModel> getAllData();
    }
}
