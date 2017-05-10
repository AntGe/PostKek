using PostKek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.BindingModels
{
    public class EditPostBm
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Contents { get; set; }
        public string PictureURL { get; set; }
    }
}
