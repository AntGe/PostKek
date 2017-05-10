using PostKek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Services
{
    public class LikeServices : Service
    {
        public bool CheckIfUserLikesPost(int postId, int userId)
        {
            using (this.Context)
            {
                return this.Context.Likes.Where(l => l.UserId == userId && l.PostId == postId).Any();
            }
        }
    }
}
