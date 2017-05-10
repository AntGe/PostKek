using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PostKek.Models;
using PostKek.Models.BindingModels;
using PostKek.Models.ViewModels;
using PostKek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostKek.Controllers
{
     
    [RoutePrefix("posts")]
    public class PostController : Controller
    { 
        public PostController()
        {
            this.services = new PostServices();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }
         
        protected PostServices services { get; set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
         
        public PartialViewResult AddComment(int id, string comment)
        {
            StatusReportVm vm = this.services.AddCommentToPost(id, User.Identity.GetUserId(), comment);
            return PartialView("_StatusReport", vm);
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult EditPost(int id)
        {
            EditPostBm vm = this.services.GetPostToEdit(id); 
            return View(vm);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult EditPost([Bind(Include = "Title, Contents, PictureURL, Id, User")] EditPostBm bind, int id)
        {
            if (ModelState.IsValid)
            {
                this.services.EditAPost(id, bind.Title, bind.Contents, bind.PictureURL);
                return View(bind);
            }
            else
            {
                return View(bind);
            }
        }

        [HttpGet]
        [Route("single/{id:int}")] 
        public ActionResult SinglePost(int id)
        {
            SinglePostVm vm = this.services.GetPostById(id, User.Identity.GetUserId());
            vm.CurrentUserId = User.Identity.GetUserId();
            return View(vm);
        }

        [HttpGet] 
        public PartialViewResult GetCommentsForPost(int id)
        {
            IEnumerable<SingleCommenVm> vms = this.services.GetCommentsForPost(id); 
            return PartialView("_CommentsSection", vms);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult AllPosts()
        {
           IEnumerable<SinglePostVm> vms =  this.services.GetAllPosts();
            return View(vms);
        }

        [HttpGet]
        [Route("add")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult AddPost()
        {  
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult AddPost([Bind(Include = "Title, Contents, PictureURL")] AddPostBm bind)
        { 
            if (this.ModelState.IsValid)
            {
                
                this.services.AddPost(bind.Title, User.Identity.GetUserId(), bind.Contents, bind.PictureURL);

                return this.RedirectToAction("Index", "Home");
            }
            else
            { 
                return View();
            }
        } 

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
