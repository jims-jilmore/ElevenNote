using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Enter At Least 1 Character")]
        [MaxLength(20, ErrorMessage = "Too Many Characters | Max 20")]
        public string CategoryTitle { get; set; }
    }
}
