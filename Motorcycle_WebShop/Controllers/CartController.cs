﻿using Microsoft.AspNetCore.Mvc;
using Motorcycle_WebShop.Data;
using Motorcycle_WebShop.Extensions;
using Motorcycle_WebShop.Models;

namespace Motorcycle_WebShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "_cart";
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionKeyName);
            if(cart == null) cart = new List<CartItem>();
            decimal total = 0;
            foreach (CartItem item in cart)
            {
                total += item.GetTotal();
            }
            ViewBag.CartTotal = total;
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionKeyName);
            if(cart == null) cart = new List<CartItem>();

            if(cart.Count == 0)
            {
                CartItem item = new CartItem()
                {
                    Product = _context.Product.Find(productId),
                    Quantity = 1
                };
                cart.Add(item);
                HttpContext.Session.SetObjectAsJson(SessionKeyName, cart);
            }
            else
            {
                bool found = false;
                foreach(CartItem item in cart)
                {
                    if(item.Product.Id == productId)
                    {
                        item.Quantity++;
                        found = true;
                        break;
                    }
                }
                if(!found)
                {
                    CartItem item = new CartItem()
                    {
                        Product = _context.Product.Find(productId),
                        Quantity = 1
                    };
                    cart.Add(item);
                }
                HttpContext.Session.SetObjectAsJson(SessionKeyName, cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            return RedirectToAction("Index");
        }

    }
}
