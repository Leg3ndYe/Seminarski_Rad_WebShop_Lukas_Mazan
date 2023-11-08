using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motorcycle_WebShop.Data;
using Motorcycle_WebShop.Models;

namespace Motorcycle_WebShop.Controllers
{
    [Authorize(Roles = "Admin,Chief executive officer,Moderator,Support")]
    public class AdminOrderItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminOrderItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        private string GetProductTitle(OrderItem item)
        {
             var orderItem = (from product in _context.Product
                               where product.Id == item.ProductId
                               select product.Title).FirstOrDefault();

            return orderItem;
        }
        // GET: AdminOrderItem
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null) return RedirectToAction("Index", "AdminOrder");

            var orderItems = await _context.OrderItem.Where(x => x.OrderId == id).ToListAsync();

            foreach (var item in orderItems)
            {
                item.ProductTitle = GetProductTitle(item);
            }
            return View(orderItems);
        }

        // GET: AdminOrderItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderItem == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            orderItem.ProductTitle = GetProductTitle(orderItem);
            return View(orderItem);
        }

        // GET: AdminOrderItem/Create
        public IActionResult Create()
        {
            return NotFound();
        }

        // POST: AdminOrderItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("Id,ProductId,OrderId,Quantity,Price")] OrderItem orderItem)
        {
            return NotFound();

            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(orderItem);
        }

        // GET: AdminOrderItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderItem == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            orderItem.ProductTitle = GetProductTitle(orderItem);
            return View(orderItem);
        }

        // POST: AdminOrderItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,OrderId,Quantity,Price")] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return NotFound();
            }
            if (orderItem.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Quantity must be greater than 0");
            }
            if (orderItem.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price must be greater than 0");
            }
            ModelState.Remove("ProductTitle");

            if (ModelState.IsValid)
            {
                try
                {
                    var old_orederItem = await _context.OrderItem.FindAsync(id);
                    var quantity_diff = orderItem.Quantity - old_orederItem.Quantity;
                    var price_diff = orderItem.Price - old_orederItem.Price;
                    if (quantity_diff < 0)
                    {
                        _context.Product.Find(orderItem.ProductId).Quantity += Math.Abs(quantity_diff);
                    }
                    if (quantity_diff > 0)
                    {
                        var available_quantity = _context.Product.Find(orderItem.ProductId).Quantity;
                        if (available_quantity < quantity_diff)
                        {
                            ModelState.AddModelError("Quantity", $"Only {available_quantity} items are available, you tried to add {quantity_diff}");
                            orderItem.ProductTitle = GetProductTitle(orderItem);
                            return View(orderItem);
                        }
                        _context.Product.Find(orderItem.ProductId).Quantity -= quantity_diff;
                    }
                    if (price_diff != 0 || quantity_diff != 0)
                    {
                        var old_price = old_orederItem.Price * old_orederItem.Quantity;
                        var new_price = orderItem.Price * orderItem.Quantity;
                        _context.Order.Find(orderItem.OrderId).Total += new_price - old_price;
                    }
                    old_orederItem.Quantity = orderItem.Quantity;
                    old_orederItem.Price = orderItem.Price;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id = orderItem.OrderId});
            }
            orderItem.ProductTitle = GetProductTitle(orderItem);
            return View(orderItem);
        }

        // GET: AdminOrderItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderItem == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            orderItem.ProductTitle = GetProductTitle(orderItem);
            return View(orderItem);
        }

        // POST: AdminOrderItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderItem'  is null.");
            }
            var orderItem = await _context.OrderItem.FindAsync(id);
            int? orderId = orderItem.OrderId;
            if (orderItem != null)
            {
                _context.Order.Find(orderItem.OrderId).Total -= orderItem.Price * orderItem.Quantity;
                _context.Product.Find(orderItem.ProductId).Quantity += orderItem.Quantity;
                _context.OrderItem.Remove(orderItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id = orderId});
        }

        private bool OrderItemExists(int id)
        {
          return (_context.OrderItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
