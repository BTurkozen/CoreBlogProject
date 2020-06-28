using CoreBlogProject.Areas.Management.ViewModels;
using CoreBlogProject.Helpers;
using CoreBlogProject.Models;
using CoreBlogProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]/[action]")]
    //[Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: CategoriesController
        public ActionResult Index()
        {
            return View(_categoryRepository.AllCategories);
        }


        // GET: CategoriesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    CategoryId = cvm.CategoryId,
                    CategoryName = cvm.CategoryName,
                    Slug = UrlServices.URLFriendly(cvm.Slug)
                };
                _categoryRepository.CreateCategory(newCategory);
                if (await _categoryRepository.SaveChangesAsync())
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();

        }

        // GET: CategoriesController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Category());
            }
            var category = _categoryRepository.GetCategoryId((int)id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.CategoryId > 0)
            {
                _categoryRepository.UpdateCategory(category);
            }
            _categoryRepository.CreateCategory(category);
            if (await _categoryRepository.SaveChangesAsync())
            {
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            await _categoryRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
