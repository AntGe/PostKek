using AutoMapper;
using PostKek.Data;
using PostKek.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Services
{
    public class PostServices : Service
    {
        public PostServices()
        {
           this.LikeServices = new LikeServices();
           this.UserServices = new UserServices();
        }
        public LikeServices LikeServices { get; set; }
        public UserServices UserServices { get; set; }
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

        public IEnumerable<SingleCommenVm> GetCommentsForPost(int postId)
        {
            IEnumerable<Comment> comments = this.Context.Posts.FirstOrDefault(p => p.Id == postId).Comments;
            IEnumerable<SingleCommenVm> commentVms = Mapper.Map<IEnumerable<Comment>, IEnumerable<SingleCommenVm>>(comments);

            return commentVms;
        }

        public SinglePostVm GetPostById(int id, string userId)
        {
            Post post = this.Context.Posts.FirstOrDefault(c => c.Id == id);
            SinglePostVm postVm = Mapper.Map<Post, SinglePostVm>(post);
            User user = this.UserServices.GetUserByLongId(userId);
            if (user != null)
            { 
                postVm.IsLiked = post.Likes.Any(l => l.UserId == user.Id);
            }
            return postVm;
        }

        public IEnumerable<SinglePostVm>GetAllPosts()
        {
            IEnumerable <Post> posts = this.Context.Posts;
            IEnumerable<SinglePostVm> postsVms = Mapper.Map<IEnumerable<Post>, IEnumerable<SinglePostVm>>(posts); 
            return postsVms;
        }
    }
}
