using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Motorcycle_WebShop.Data;
using Motorcycle_WebShop.Models;
using Motorcycle_WebShop.Controllers;
using Microsoft.AspNetCore.Http.Extensions;

namespace Motorcycle_WebShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUserManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        
        public AdminUserManagementController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        // GET: AdminUserManagement
        public async Task<IActionResult> Index()
        {
            //TODO IS ACTIVE VISIBLE
            List<ApplicationUser> appUsers = _context.Users.ToList();
            
            ViewBag.UserRoles = _context.UserRoles.ToList();
            ViewBag.Roles = _context.Roles.ToList();

            return View(appUsers);   
        }

        // GET: AdminUserManagement/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: AdminUserManagement/Create
        public IActionResult Create()
        {
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        // POST: AdminUserManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser applicationUser, IdentityUserRole<string> userRole)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Name == applicationUser.Role);
            if (role == null)
            {
                return NotFound();
            }
            userRole = new IdentityUserRole<string>
            {
                UserId = applicationUser.Id,
                RoleId = role.Id
            };

            applicationUser.NormalizedEmail = applicationUser.Email.ToUpper();
            applicationUser.NormalizedUserName = applicationUser.Email.ToUpper();
            applicationUser.UserName = applicationUser.Email;

            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordhash = hasher.HashPassword(null, applicationUser.Password);

            applicationUser.PasswordHash = passwordhash;
            applicationUser.ConfirmationToken = Guid.NewGuid().ToString();

            if (applicationUser.SendConfirmationEmail == true)
            {
                string confirmationLink = Url.Action("ConfirmEmail", "Home", new { token = applicationUser.ConfirmationToken }, Request.Scheme);
                ConfirmationEmailSender confesender = new ConfirmationEmailSender(_configuration);
                confesender.SendConfirmationEmail(applicationUser.Email, confirmationLink);
            }

            ModelState.Remove("Orders");
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Roles = _context.Roles.ToList();
            return View(applicationUser);
        }

        // GET: AdminUserManagement/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: AdminUserManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string? id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Orders");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(applicationUser.Id))
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
            return View(applicationUser);
        }

        // GET: AdminUserManagement/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: AdminUserManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserManagement'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
       
    }
}
