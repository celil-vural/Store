using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Concrete;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RepositoryManager<Category> _repositoryManager;

        public CategoryController(RepositoryManager<Category> repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IActionResult Index()
        {
            var model = _repositoryManager.GetList();
            return View(model);
        }
    }
}
