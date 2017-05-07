using PostKek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Services
{
    public class PostServices : Service
    {
        public void AddPost(string title, string userId, string contents, string pictureURL)
        {
            UserServices userServices = new UserServices();
            Post post = new Post();
            post.Title = title;
            post.Contents = contents;
            post.PictureURL = pictureURL;
            post.DateCreated = DateTime.Now;
            post.IsDeleted = false;
            post.UserId = userServices.GetUserByLongId(userId).Id;
            using (this.Context)
            {
                this.Context.Posts.Add(post);
                this.Context.SaveChanges(); 
            }
        }
    }
}
