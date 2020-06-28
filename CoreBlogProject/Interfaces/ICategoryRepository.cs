using CoreBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryId(int categoryId);
        List<Category> AllCategories { get; }
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);

        Task<bool> SaveChangesAsync();
    }
}
