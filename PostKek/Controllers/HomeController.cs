using PostKek.Models.ViewModels;
using PostKek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostKek.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            this.PostServices = new PostServices();
        }

        public PostServices PostServices { get; set; }
        public ActionResult Index()
        {
            IEnumerable<SinglePostVm> vms = this.PostServices.GetTopLikedPosts();
            return View(vms);
        } 
    }
}