﻿using System;
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
    public class AdminProductImageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminProductImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminProductImage
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return RedirectToAction("Index", "AdminProduct");
            ViewBag.ProductId = id;
              return _context.ProductImage != null ? 
                          View(await _context.ProductImage.Where(x=>x.ProductId==id).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProductImage'  is null.");
        }

        // GET: AdminProductImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductImage == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // GET: AdminProductImage/Create
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("Index", "AdminProduct");
            if (_context.Product.Count(p => p.Id == id) == 0) return RedirectToAction("Index", "AdminProduct");
            return View(new ProductImage() { ProductId = (int)id});
        }

        // POST: AdminProductImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,IsMainImage,Title,FilePath")] ProductImage productImage)
        {
            ModelState.Remove("ProductTitle");
            if (HttpContext.Request.Form.Files.Count > 0) ModelState.Remove("FilePath");
            if (ModelState.IsValid)
            {
                var imageFile = HttpContext.Request.Form.Files.FirstOrDefault();
                var uploadPath = Path.Combine("wwwroot", "images", "products", productImage.ProductId.ToString());
                if(!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                if(imageFile != null)
                {
                    var filePath = Path.Combine(uploadPath, imageFile.FileName);
                    using(var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    filePath = filePath.Replace("wwwroot\\", "/").Replace("\\", "/");
                    productImage.FilePath = filePath;
                }
                productImage.Id = 0;
                _context.Add(productImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), productImage.ProductId);
            }
            return View(productImage);
        }

        // GET: AdminProductImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return RedirectToAction("Index", "AdminProduct");
            if (id == null || _context.ProductImage == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage.FindAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return View(productImage);
        }

        // POST: AdminProductImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,IsMainImage,Title,FilePath")] ProductImage productImage)
        {
            return RedirectToAction("Index", "AdminProduct");
            if (id != productImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductImageExists(productImage.Id))
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
            return View(productImage);
        }

        // GET: AdminProductImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductImage == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // POST: AdminProductImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductImage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductImage'  is null.");
            }
            var productImage = await _context.ProductImage.FindAsync(id);
            if (productImage != null)
            {
                var filePath = "wwwroot" + productImage.FilePath.Replace("/","\\");
                System.IO.File.Delete(filePath);
                _context.ProductImage.Remove(productImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id=productImage.ProductId});
        }

        private bool ProductImageExists(int id)
        {
          return (_context.ProductImage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
