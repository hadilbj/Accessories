using Accessories.Models;
using Microsoft.AspNetCore.Mvc;
using Products.Models.Repositories;
using System.Diagnostics;

namespace Accessories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository productRepository;
        private readonly AppDbContext appContext;
        public HomeController (ProductRepository productRepository, AppDbContext appContext)
        {
            this.productRepository = productRepository;
            this.appContext = appContext;
        }

        public IActionResult Index()
        {
            var products =productRepository.GetAll();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Page()
        {
            var products = appContext.Products.ToList();
            return View(products);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}