using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Motorcycle_WebShop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motorcycle_WebShop.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? Role { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }

        [NotMapped]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Password is too short. It can contain minimum of 5 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).+$", ErrorMessage = "Password must contain at least one uppercase letter and one special character.")]
        public string? Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match. Please check your spelling.")]
        public string? PasswordConfirmation { get; set; }

        [NotMapped]
        public bool IsActive { get; set; }

        [NotMapped]
        public bool SendConfirmationEmail { get; set; }

        public string? ConfirmationToken { get; set; } 

        [ForeignKey("UserId")]
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "4bc6d9be - 018d - 4cd9 - acaa - d855942ee8d9",
                Name = "Chief executive officer",
                NormalizedName = "CHIEF EXECUTIVE OFFICER"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "811bf54e-ec17-457f-917b-c432d1060070",
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "edffea81-92bf-4400-84f3-047a9f72cbc7",
                Name = "Support",
                NormalizedName = "SUPPORT"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2cd04bd9-83ff-49a3-a1b7-e97a5e9896d9",
                Name = "Secretary",
                NormalizedName = "SECRETARY"
            });

            base.OnModelCreating(builder);
        }
    }
}
    