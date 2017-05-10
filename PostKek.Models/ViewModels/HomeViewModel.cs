using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.ViewModels
{
    public class HomeViewModel
    {
        IEnumerable<SinglePostVm> topDiscussedPosts { get; set; }
    }
}
