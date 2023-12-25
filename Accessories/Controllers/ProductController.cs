
using Accessories.Models;
using Accessories.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting; // Ajout de la référence pour IWebHostEnvironment
using Accessories.ViewModels;
using Products.Models.Repositories;
using Accessories.Models;
using Microsoft.AspNetCore.Authorization;

namespace Accessories.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;
        private readonly ICartRepository cartRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment, ProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.webHostEnvironment = webHostEnvironment;

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = productRepository.GetAll();
            return View(model);
        }

        public ActionResult Details (int v)
        {
            var model = productRepository.GetById(v);
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
        public ActionResult Create(ProductViewModel model)
        {


            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                // If the Photo property on the incoming model object is not null, then the user has selected an image to upload.
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product newPro = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    categoryid = model.categoryid,
                    Photo = uniqueFileName
                };
                productRepository.Add(newPro);
                return RedirectToAction("details", new { id = newPro.Id });
            }
            return View();
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

        [HttpGet]
        public IActionResult CreateVM ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVM(ProductViewModel productvm)
        {
            string filename = productvm.Photo.FileName;

            return View();
        }
    }
}
