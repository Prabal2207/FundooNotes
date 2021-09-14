using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
   public class NotesModel
    {
        public long UserId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Reminder { get; set; }


        public string Color { get; set; }

        public string image { get; set; }

        public bool IsArchive { get; set; }



        public bool IsTrash;
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

    }
}
