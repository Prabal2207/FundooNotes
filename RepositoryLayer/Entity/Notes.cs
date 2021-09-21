﻿using System;
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
        public long NotesId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Reminder { get; set; }
        public string Color { get; set; }

        public string image { get; set; }

        public bool IsArchive { get; set; }

        public bool isPin { get; set; }

        public bool IsTrash { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        
        [Display(Name ="User")]
        public virtual long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User userId { get; set; }
}
}
