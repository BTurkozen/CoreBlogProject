using CoreBlogProject.Data;
using CoreBlogProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category GetCategoryId(int categoryId)
        {
            return _dbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
        }
        public List<Category> AllCategories => _dbContext.Categories.ToList();

        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
        }
        public void DeleteCategory(int id)
        {
            _dbContext.Remove(GetCategoryId(id));
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
