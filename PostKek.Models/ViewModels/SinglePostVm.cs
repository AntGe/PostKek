using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.ViewModels
{
    public class SinglePostVm
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public string PictureURL { get; set; } 
        public bool IsLiked { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
