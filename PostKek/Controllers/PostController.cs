using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PostKek.Models;
using PostKek.Models.BindingModels;
using PostKek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostKek.Controllers
{
     
    [RoutePrefix("Posts")]
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

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
         
        [HttpGet]
        [Route("add")]
        [Authorize(Roles = "User")]
        public ActionResult AddPost()
        {  
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "User")]
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

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
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
