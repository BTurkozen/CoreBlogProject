using CoreBlogProject.Data;
using CoreBlogProject.Interfaces;
using CoreBlogProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileManager _file;

        public PostRepository(ApplicationDbContext dbContext, IFileManager file)
        {
            _dbContext = dbContext;
            _file = file;
        }

        public Post GetPostId(int postId)
        {
            return _dbContext.Posts.FirstOrDefault(x => x.PostId == postId);
            //comment eklendıgınde include(x => x.Comment)
        }

        public List<Post> AllPosts => _dbContext.Posts.Include(x => x.Category).ToList();

        public void CreatePost(Post post)
        {
            _dbContext.Posts.Add(post);
        }

        public void UpdatePost(Post post)
        {
            
            _dbContext.Posts.Update(post);
        }

        public void DeletePost(int id)
        {
            Post postD = _dbContext.Posts.FirstOrDefault(x => x.PostId == id);
            var imagePath = postD.PhotoPath;
            _file.DeleteImage(imagePath);

            _dbContext.Remove(GetPostId(id));
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

    }
}
