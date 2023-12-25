using Accessories.Models;
using Accessories.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Accessories.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class CategoriesController : Controller
    {
        private readonly CategoryRepository categoryRepository;

        public CategoriesController(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = categoryRepository.GetAll();
            return View(model);
        }

        public ActionResult Details (int id)
        {
            var model = categoryRepository.GetById(id);
            return View(model);
        }

        //GET : create
        public ActionResult Create ()
        {
            return View();
        }

        //POST : create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Category category)
        {
            try
            {
                categoryRepository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET : edit
        public ActionResult Edit (int id)
        {
            Category category = categoryRepository.GetById(id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //POST : edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Category c)
        {
            try
            {
                 categoryRepository.Edit(c);
                 return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET : delete
        public ActionResult Delete (int id)
        {
            var model = categoryRepository.GetById(id);
            return View(model);
        }

        //POST : delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (Category c)
        {
            try
            {
                categoryRepository.Delete(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
