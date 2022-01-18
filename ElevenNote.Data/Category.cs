using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } //Key 
        [ForeignKey("Note")]
        public int NoteId { get; set; } //Foreign Key 
        [Required]
        public string CategoryTitle { get; set; }

        public virtual ICollection<Note> Note { get; set; }


    }
}
