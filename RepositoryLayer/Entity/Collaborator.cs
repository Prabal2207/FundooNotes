using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Collaborator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollaboratorId { get; set; }

        [Display(Name = "User")]
        public virtual long? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }


        [Display(Name = "Notes")]
        public virtual long NotesId { get; set; }

        [ForeignKey("NotesId")]
        public virtual Notes Note { get; set; }

        public string CollaboratorEmailId { get; set; }


    }
}
