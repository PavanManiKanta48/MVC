using BulkBookWeb.Data;
using BulkBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
