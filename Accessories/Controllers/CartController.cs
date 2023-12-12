using Accessories.Models;
using Accessories.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Accessories.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductRepository productRepository;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            // Retrieve all items from the cart repository
            IList<Cart> cartItems = cartRepository.GetAll();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, string userId, int quantity)
        {
            // Add logic to retrieve product information by productId
            // This could involve another repository for products

            // Create a new Cart object with the provided information
            Cart cartItem = new Cart
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };

            // Add the cart item to the repository
            cartRepository.Add(cartItem);

            // Redirect to the cart index page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddProductToCart(int productId)
        {
            var product = productRepository.GetById(productId);

            if (product != null)
            {
                // Add the product to the cart
                var cartItem = new Cart
                {
                    UserId = "userId", // Replace with the actual user ID
                    ProductId = product.Id,
                    Quantity = 1 // You might want to allow the user to specify the quantity
                };

                cartRepository.Add(cartItem);
            }

            // Redirect to the cart index page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            // Retrieve cart item by ID
            Cart cartItem = cartRepository.GetAll().FirstOrDefault(c => c.Id == cartItemId);

            if (cartItem != null)
            {
                // Remove the cart item from the repository
                cartRepository.Delete(cartItem);
            }

            // Redirect to the cart index page
            return RedirectToAction("Index");
        }
    }
}
