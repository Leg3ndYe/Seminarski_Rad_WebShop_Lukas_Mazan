﻿using System;
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
using Motorcycle_WebShop.Data.Migrations;

namespace Motorcycle_WebShop.Controllers
{
    [Authorize(Roles = "Admin,Chief executive officer,Moderator,Support")]
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
            List<ApplicationUser> appUsers = _context.Users.Where(x => x.IsActive == true).ToList();
            
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
        public async Task<IActionResult> Create(ApplicationUser applicationUser, IdentityUserRole<string> userRole, IFormFile imageFile)
        {
            var role = AddUserRole(applicationUser, userRole);
            AddUserInfo(applicationUser);
            SendConfirmationEmail(applicationUser);           

            if (HttpContext.Request.Form.Files.Count > 0) ModelState.Remove("imageFile");
            ModelState.Remove("Orders");         
            //image file null for some reason...
            if (ModelState.IsValid)
            {
                UploadImage(applicationUser,imageFile);
                _context.Add(applicationUser);
                _context.UserRoles.Add(role);
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
            ViewBag.Roles = _context.Roles.ToList();
            return View(user);
        }

        // POST: AdminUserManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser applicationUser)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            var userRole = _context.UserRoles.FirstOrDefault(y => y.UserId == id);
            var role = _context.Roles.FirstOrDefault(z => z.Name == applicationUser.Role);

            if (id != user.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Orders");
            if (ModelState.IsValid)
            {
                if(user.Role != applicationUser.Role)
                {
                    _context.UserRoles.Remove(userRole);
                    await _context.SaveChangesAsync();

                    userRole = new IdentityUserRole<string>
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    };
                }

                UserInfo(user, applicationUser);

                try
                {
                    if(user.Role != applicationUser.Role) _context.UserRoles.Add(userRole);
                    user.Role = applicationUser.Role;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewBag.Roles = _context.Roles.ToList();
            return View(user);
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
                if(user.AvatarFilePath != null)
                {
                    var filePath = "wwwroot" + user.AvatarFilePath.Replace("/", "\\");
                    System.IO.File.Delete(filePath);
                }  
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async void UploadImage(ApplicationUser applicationUser, IFormFile imageFile)
        {
            imageFile = HttpContext.Request.Form.Files.FirstOrDefault();
            var uploadPath = Path.Combine("wwwroot", "images", "avatars", applicationUser.Id.ToString());
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (imageFile != null)
            {
                var filePath = Path.Combine(uploadPath, imageFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                filePath = filePath.Replace("wwwroot\\", "/").Replace("\\", "/");
                applicationUser.AvatarFilePath = filePath;
            }
        }

        public IdentityUserRole<string> AddUserRole(ApplicationUser applicationUser, IdentityUserRole<string> userRole)
        {
            if (applicationUser.Role == null)
            {
                applicationUser.Role = "User";
            }
            var role = _context.Roles.FirstOrDefault(x => x.Name == applicationUser.Role);
            userRole = new IdentityUserRole<string>
            {
                UserId = applicationUser.Id,
                RoleId = role.Id
            };
            return userRole;
        }

        public void AddUserInfo(ApplicationUser applicationUser)
        {
            applicationUser.NormalizedEmail = applicationUser.Email.ToUpper();
            applicationUser.NormalizedUserName = applicationUser.Email.ToUpper();
            applicationUser.UserName = applicationUser.Email;

            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordhash = hasher.HashPassword(null, applicationUser.Password);

            applicationUser.PasswordHash = passwordhash;
            applicationUser.ConfirmationToken = Guid.NewGuid().ToString();

            if (applicationUser.LastLoginAt == null)
            {
                applicationUser.LastLoginAt = new DateTime(0001, 01, 01);
            }

            if (applicationUser.LastKnownIpAddress == null)
            {
                applicationUser.LastKnownIpAddress = "Has not logged in yet.";
            }
        }

        public void SendConfirmationEmail(ApplicationUser applicationUser)
        {
            if(applicationUser.SendConfirmationEmail == true) 
            { 
                string confirmationLink = Url.Action("ConfirmEmail", "Home", new { token = applicationUser.ConfirmationToken }, Request.Scheme);
                ConfirmationEmailSender confesender = new ConfirmationEmailSender(_configuration);
                confesender.SendConfirmationEmail(applicationUser.Email, confirmationLink);
            }
        }

        public void UserInfo(ApplicationUser user, ApplicationUser applicationUser)
        {
            user.Name = applicationUser.Name;
            user.Email = applicationUser.Email;
            user.Password = applicationUser.Password;
            user.PasswordConfirmation = applicationUser.PasswordConfirmation;
            user.IsActive = applicationUser.IsActive;
            user.SendConfirmationEmail = applicationUser.SendConfirmationEmail;
            user.EmailConfirmed = applicationUser.EmailConfirmed;

            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordhash = hasher.HashPassword(null, user.Password);

            user.PasswordHash = passwordhash;
        }

    }
}
