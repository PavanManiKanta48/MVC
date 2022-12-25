using BulkBookWeb.Data;
using BulkBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategorylist = _dbContext.categories;
            return View(objCategorylist);
        }
        //Get
        public IActionResult Create()
        {            
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.categories.Add(category);
                _dbContext.SaveChanges();
                TempData["Success"] = "Item Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int? Id)
        {
            if(Id == 0 || Id == null)
            {
                return NotFound();
            }
            var CategoryIdFromDb = _dbContext.categories.Find(Id);
            if (CategoryIdFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryIdFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.categories.Update(obj);
                _dbContext.SaveChanges();
                TempData["Success"] = "Item Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var CategoryIdFromDb = _dbContext.categories.Find(Id);
            if (CategoryIdFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryIdFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            var obj = _dbContext.categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.categories.Remove(obj);
            _dbContext.SaveChanges();
            TempData["Success"] = "Item deleted Successfully";
            return RedirectToAction("Index");

            return View(Id);
        }
    }
}
