﻿using CoreBlogProject.Models;
using CoreBlogProject.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogProject.Repositories
{
    public interface IPostRepository
    {
        Post GetPostId(int postId);
        List<Post> AllPosts { get; }
        void CreatePost(Post post); 
        void UpdatePost(Post post);
        void DeletePost(int id);

        void AddComment(SubComment comment);

        Task<bool> SaveChangesAsync();
    }
}
