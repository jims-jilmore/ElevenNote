﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class CategoryAssignment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }
        public virtual Note Note { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
