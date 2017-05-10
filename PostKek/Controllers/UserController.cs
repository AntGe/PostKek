using PostKek.Models.ViewModels;
using PostKek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostKek.Controllers
{
    [RoutePrefix("users")]
    public class UserController : Controller
    {
        public UserController()
        {
            this.UserServices = new UserServices();
        }

        public UserServices UserServices { get; set; }
        [Route("all")]
        public ActionResult AllUsers()
        {
            IEnumerable<SingleUserVm> userVms = this.UserServices.GetAllUsers();
            return View(userVms);
        }
    }
}
