using Accessories.Models;
using Accessories.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Accessories.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public ProductController(ProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            var model = productRepository.GetAll();
            return View(model);
        }

        public ActionResult Details (int id)
        {
            var model = productRepository.GetById(id);
            return View(model);
        }

        //GET : create
        public ActionResult Create()
        {
            return View();
        }

        //POST : create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                productRepository.Add(product);
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
            Product product = productRepository.GetById(id);
            if  (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        //POST : edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Product p)
        {
            try
            {
                productRepository.Edit(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET : delete
        public ActionResult Delete(int id)
        {
            var model = productRepository.GetById(id);
            return View(model);
        }

        //POST : delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product p)
        {
            try
            {
                productRepository.Delete(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
