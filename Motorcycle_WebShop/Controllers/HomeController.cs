using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Motorcycle_WebShop.Data;
using Motorcycle_WebShop.Extensions;
using Motorcycle_WebShop.Models;
using System.Diagnostics;

namespace Motorcycle_WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "_cart";
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product(int? id, int? categoryId)
        {
            List<Product> products = _context.Product.Where(x => x.IsActive == true).ToList();

            if(id != null)
            {
                var product = products.Where(p => p.Id == id).FirstOrDefault();
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
                return View("ProductDetails", product);
            }

            foreach (var product in products)
            {
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == product.Id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
            }

            if (categoryId != null)
            {
                products = products.Where(p => p.ProductCategories.Any(p => p.CategoryId == categoryId)).ToList();
            }

            ViewBag.Categories = _context.Category.ToList();
            return View(products);
        }

        public IActionResult Order(List<string> errors)
        {
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionKeyName);
            if (cart == null) return RedirectToAction("Index");
            if (cart.Count == 0) return RedirectToAction("Index");

            for(int i=0; i<cart.Count; i++)
            {
                var product = _context.Product.Find(cart[i].Product.Id);
                if(product== null)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product not found and was removed from cart.");
                    continue;
                }
                if(product.Quantity < cart[i].Quantity)
                {
                    cart[i].Quantity = product.Quantity;
                    errors.Add("Product quantity was reduced to available quantity!");
                }
                if(!product.IsActive)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product is not active and was removed from cart!");
                    continue;
                }
                
            }

            HttpContext.Session.SetObjectAsJson(SessionKeyName, cart);

            foreach(CartItem item in cart)
            {
                item.Product.ProductImages=_context.ProductImage.Where(pi => pi.ProductId==item.Product.Id).ToList();
                item.Product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == item.Product.Id).ToList();
            }

            ViewBag.Errors = errors;

            return View(cart);
        }

        public IActionResult CreateOrder(Order order, bool shippingsameaspersonal)
        {
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionKeyName);
            if(cart == null)
            {
                return RedirectToAction("Index");
            }
            if(cart.Count == 0)
            {
                return RedirectToAction("Index");
            }

            var errors = new List<string>();

            for (int i = 0; i < cart.Count; i++)
            {
                var product = _context.Product.Find(cart[i].Product.Id);
                if (product == null)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product not found and was removed from cart.");
                    continue;
                }
                if (product.Quantity < cart[i].Quantity)
                {
                    cart[i].Quantity = product.Quantity;
                    errors.Add("Product quantity was reduced to available quantity!");
                }
                if (!product.IsActive)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product is not active and was removed from cart!");
                    continue;
                }

            }

            HttpContext.Session.SetObjectAsJson(SessionKeyName, cart);

            if(errors.Count > 0)
            {
                return RedirectToAction("Order", new {errors});
            }

            return RedirectToAction("Order", new {errors});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}