using System;
using System.Collections.Generic;
using System.Data;
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
    public class AdminOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminOrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        private List<OrderItem> GetItemsForOrder(int orderId)
        {
            return (
                from order_item in _context.OrderItem
                where order_item.OrderId == orderId
                select new OrderItem
                {
                    Id = order_item.Id,
                    OrderId = order_item.OrderId,
                    ProductId = order_item.ProductId,
                    Quantity = order_item.Quantity,
                    Price = order_item.Price,
                    ProductTitle = (
                                    from product in _context.Product
                                    where product.Id == order_item.ProductId
                                    select product.Title
                                    ).FirstOrDefault()
                }
                ).ToList();
        }
        // GET: AdminOrder
        public async Task<IActionResult> Index()
        {
              return _context.Order != null ? 
                          View(await _context.Order.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Order'  is null.");
        }

        // GET: AdminOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderItems = GetItemsForOrder(order.Id);

            return View(order);
        }

        // GET: AdminOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            order.OrderItems = GetItemsForOrder(order.Id);
            return View(order);
        }

        // POST: AdminOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,Total,BillingFirstName,BillingLastName,BillingEmail,BillingPhone,BillingAddress,BillingCity,BillingPostalCode,BillingCountry,ShippingFirstName,ShippingLastName,ShippingEmail,ShippingPhone,ShippingAddress,ShippingCity,ShippingPostalCode,ShippingCountry,Message,UserId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }
            ModelState.Remove("OrderItems");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            order.OrderItems = GetItemsForOrder(order.Id);
            return View(order);
        }

        // GET: AdminOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.OrderItems = GetItemsForOrder((int)id);
            return View(order);
        }

        // POST: AdminOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   
            if (_context.Order == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                foreach (var order_item in _context.OrderItem.Where(oi => oi.OrderId == order.Id))
                {
                    _context.Product.Find(order_item.ProductId).Quantity += order_item.Quantity;
                    _context.OrderItem.Remove(order_item);
                }
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Order?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
