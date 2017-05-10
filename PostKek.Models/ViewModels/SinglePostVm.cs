﻿using PostKek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Models.ViewModels
{
    public class SinglePostVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string PictureURL { get; set; } 
        public bool IsLiked { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
        public string CurrentUserId { get; set; }
    }
}
