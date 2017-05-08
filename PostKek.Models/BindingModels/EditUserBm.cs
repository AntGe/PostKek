using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.BindingModels
{
    public class EditUserBm
    { 
        public string Name { get; set; }
        public string Email { get; set; }
        public string PictureURL { get; set; } 
        public int Id { get; set; }
    }
}
