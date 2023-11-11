using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Motorcycle_WebShop.Data;
using Motorcycle_WebShop.Extensions;
using Motorcycle_WebShop.Models;
using System.Diagnostics;
using System.Linq;

namespace Motorcycle_WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public const string SessionKeyName = "_cart";
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index(int? id, int? categoryId)
        {
            List<Product> products = _context.Product.Where(x => x.IsActive == true).ToList();
            List<Product> uniqueRandomProductsList = new List<Product>();
            HashSet<Product> uniqueRandomProducts = new HashSet<Product>();
            Random rand = new Random();
            if(products.Count >= 12)
            {
                do
                {
                    var randomProductIndex = rand.Next(products.Count);
                    uniqueRandomProducts.Add(products[randomProductIndex]);
                } while (uniqueRandomProducts.Count < 12);
                uniqueRandomProductsList = uniqueRandomProducts.ToList();
            }
            else
            {
                uniqueRandomProductsList = products;
                
            }

            if (id != null)
            {
                var product = uniqueRandomProductsList.Where(p => p.Id == id).FirstOrDefault();
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
                return View("ProductDetails", product);
            }

            foreach (var product in uniqueRandomProductsList)
            {
                product.ProductImages = _context.ProductImage.Where(pi => pi.ProductId == product.Id).ToList();
                product.ProductCategories = _context.ProductCategory.Where(pc => pc.ProductId == product.Id).ToList();
            }

            if (categoryId != null)
            {
                products = uniqueRandomProductsList.Where(p => p.ProductCategories.Any(p => p.CategoryId == categoryId)).ToList();
            }

            return View(uniqueRandomProductsList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product(int? id, int? categoryId, string? sentence)
        {
            List<Product> products = _context.Product.Where(x => x.IsActive == true).ToList();

            if (id != null)
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

            if (!String.IsNullOrEmpty(sentence))
            {
                products = products.Where(p => p.Title.Contains(sentence, StringComparison.CurrentCultureIgnoreCase)).ToList();


                //Do ovog nikad ne dodje jer baci samo ovo iznad
                if (sentence.ToLower() == "asc")
                {
                    products = products.OrderBy(p => p.Title).ToList();
                }
                if (sentence.ToLower() == "desc")
                {
                    products = products.OrderByDescending(p => p.Title).ToList();
                }
            }

            //if (search.Page_number < 1) search.Page_number = 1;
            //if (search.Per_page > 0 && search.Page_number > 0)
            //{
            //    products = products.Skip((search.Page_number - 1) * search.Per_page).Take(search.Per_page).ToList();
            //}



            ViewBag.Categories = _context.Category.ToList();
            return View(products);
        }

        [Authorize]
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
                if (product.Quantity == 0)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product " + product.Title + " and was removed from cart!");
                    continue;
                }
                if (!product.IsActive)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product " + product.Title + "is not active and was removed from the cart!");
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

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder(Order order, string shippingsameaspersonal)
        {
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionKeyName);
            if(cart == null)
            {
                return RedirectToAction("Index", new {Message="Cart is empty! Order can't be completed!"});
            }
            if(cart.Count == 0)
            {
                return RedirectToAction("Index", new { Message = "Cart is empty! Order can't be completed!" });
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
                if (product.Quantity == 0)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product " + product.Title + " and was removed from cart!");
                    continue;
                }
                if (!product.IsActive)
                {
                    cart.RemoveAt(i);
                    i--;
                    errors.Add("Product " + product.Title + "is not active and was removed from the cart!");
                    continue;
                }

            }

            HttpContext.Session.SetObjectAsJson(SessionKeyName, cart);

            if(errors.Count > 0)
            {
                return RedirectToAction("Order", new {errors = errors});
            }

            if (shippingsameaspersonal == "on")
            {
                order.ShippingFirstName = order.BillingFirstName;
                order.ShippingLastName = order.BillingLastName;
                order.ShippingEmail = order.BillingEmail;
                order.ShippingPhone = order.BillingPhone;
                order.ShippingAddress = order.BillingAddress;
                order.ShippingCity = order.BillingCity;
                order.ShippingPostalCode = order.BillingPostalCode;
                order.ShippingCountry = order.BillingCountry;
            }
            order.DateCreated = DateTime.Now;
            order.Total = cart.Sum(x => x.Product.Price * x.Quantity);
            order.UserId = _userManager.GetUserId(User);

            ModelState.Remove("Id");
            ModelState.Remove("OrderItems");
            ModelState.Remove("shippingsameaspersonal");
            if (ModelState.IsValid) 
            {
                _context.Order.Add(order);
                _context.SaveChanges();

                int order_id = order.Id;
                foreach(var item in cart)
                {
                    OrderItem order_item = new OrderItem
                    {
                        OrderId = order_id,
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity,
                        Price = item.Product.Price
                    };

                    _context.OrderItem.Add(order_item);
                    _context.Product.Find(item.Product.Id).Quantity -= item.Quantity;
                    _context.SaveChanges();
                }
                HttpContext.Session.Remove(SessionKeyName);

                return RedirectToAction("Index", new { message = "Thank you for your purchase! :P" });
            }
            else
            {
                errors.Add("Order is not valid!");
                foreach(var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        errors.Add(modelError.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Order", new {errors = errors});
        }
        public IActionResult ConfirmEmail(string token)
        {
            var user = _context.Users.SingleOrDefault(u => u.ConfirmationToken == token);

            if (user == null)
            {
                return NotFound();
            }

            user.EmailConfirmed = true;
            _context.SaveChangesAsync();

            _signInManager.SignInAsync(user, isPersistent: false);

            return View("ConfirmEmail", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}