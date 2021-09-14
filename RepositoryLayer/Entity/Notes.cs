using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entity
{
   public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        
        public User User { get; set; }
}
}
