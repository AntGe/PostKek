using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.ViewModels
{
    public class SingleUserVm
    {
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PictureURL { get; set; }
    }
}
