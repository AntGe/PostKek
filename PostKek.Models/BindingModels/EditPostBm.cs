using PostKek.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.BindingModels
{
    public class EditPostBm
    {
        public int Id { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public string PictureURL { get; set; }
    }
}
