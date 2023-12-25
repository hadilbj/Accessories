using Accessories.Models;
using Accessories.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Accessories.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly AppDbContext context;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository, AppDbContext context)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.context = context;
        }

        public IActionResult Index()
        {
            // Retrieve all items from the cart repository
            IList<Cart> cartItems = cartRepository.GetAll();

            return View(cartItems);
        }

        [HttpPost]
        public async Task <IActionResult> AddToCart(int productId)
        {
            Product pro = await context.Products.FindAsync(productId);
            string json = Request.Cookies["Cart"];

            List<Cart> panier = string.IsNullOrEmpty(json)
                ? new List<Cart>()
                : JsonConvert.DeserializeObject<List<Cart>>(json) ?? new List<Cart>();
            Cart panier1 = panier.Where(p => p.Id == productId).FirstOrDefault();

            if (panier1 == null)
            {
                panier.Add(new Cart(pro));
                TempData["Message"] = "Product added successfully.";
            }
            else
            {
                panier1.Quantity += 1;
                TempData["Message"] = "Product quantity increased successfully.";
            }
            Response.Cookies.Append("Panier", JsonConvert.SerializeObject(panier));


            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            Cart cartItem = cartRepository.GetCartItemById(cartItemId);

            if (cartItem != null)
            {
                cartRepository.Delete(cartItem);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult UpdateQuantity(int cartItemId, int newQuantity)
        {
            // Retrieve cart item by ID
            Cart cartItem = cartRepository.GetAll().FirstOrDefault(c => c.Id == cartItemId);

            if (cartItem != null)
            {
                // Update the quantity of the cart item
                cartItem.Quantity = newQuantity;
                cartRepository.Update(cartItem);
            }

            // Redirect to the cart index page
            return RedirectToAction("Index");
        }
    }
}
