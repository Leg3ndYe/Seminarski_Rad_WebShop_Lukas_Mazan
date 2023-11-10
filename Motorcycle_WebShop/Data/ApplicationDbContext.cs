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
        public bool IsActive { get; set; }

        [NotMapped]
        public bool SendConfirmationEmail { get; set; }

        public string? ConfirmationToken { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastLoginAt { get; set; }

        public string? LastKnownIpAddress { get; set; }
        public string? AvatarFilePath { get; set; }

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
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "94a721f8-f477-40f7-aec2-057742da1c26",
                Name = "User",
                NormalizedName = "USER"
            });


            builder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "YAMAHA MT-10",
                Description = "When Yamaha launched the first MT Hyper Naked a decade ago the motorcycle world changed forever. With a clear focus on torque, agility and feel, the MT range has given riders the chance to experience the raw emotion and on-demand excitement that makes every Hyper Naked special.",
                IsActive = true,
                Price = 15199m,
                Quantity = 14
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 1,
                ProductId = 1,
                IsMainImage = true,
                Title = "MT-10.main",
                FilePath = "/images/products/1/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 2,
                ProductId = 1,
                IsMainImage = false,
                Title = "MT-10.01",
                FilePath = "/images/products/1/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 3,
                ProductId = 1,
                IsMainImage = false,
                Title = "MT-10.02",
                FilePath = "/images/products/1/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 4,
                ProductId = 1,
                IsMainImage = false,
                Title = "MT-10.03",
                FilePath = "/images/products/1/3.jpg"
            });


            builder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Title = "YAMAHA TRACER 9",
                Description = "In 2015, the first Tracer 900 changed the Sport Touring class forever. With its torque-rich CP3 engine, sporty chassis and all-round versatility, it became the bike of choice for over 50,000 European riders who wanted an agile and exciting multi-role motorcycle with plenty of attitude. Perhaps no surprise then that it’s the best-selling bike of its class.",
                IsActive = true,
                Price = 16499m,
                Quantity = 10
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 5,
                ProductId = 2,
                IsMainImage = true,
                Title = "TRACER 9.main",
                FilePath = "/images/products/2/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 6,
                ProductId = 2,
                IsMainImage = false,
                Title = "TRACER 9.01",
                FilePath = "/images/products/2/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 7,
                ProductId = 2,
                IsMainImage = false,
                Title = "TRACER 9.02",
                FilePath = "/images/products/2/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 8,
                ProductId = 2,
                IsMainImage = false,
                Title = "TRACER 9.03",
                FilePath = "/images/products/2/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Title = "YAMAHA R1",
                Description = "R1 is the most focused and high-tech Supersport bike ever built by Yamaha, ever since the launch of the original model over 25 years ago. And just about everything on the latest R1 can directly trace its origins back to the racetrack, where Yamaha’s factory racing teams and test riders have been developing and testing the advanced technology that you can now see and experience on your R1. ",
                IsActive = true,
                Price = 17399m,
                Quantity = 21
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 9,
                ProductId = 3,
                IsMainImage = true,
                Title = "R1.main",
                FilePath = "/images/products/3/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 10,
                ProductId = 3,
                IsMainImage = false,
                Title = "R1.01",
                FilePath = "/images/products/3/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 11,
                ProductId = 3,
                IsMainImage = false,
                Title = "R1.02",
                FilePath = "/images/products/3/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 12,
                ProductId = 3,
                IsMainImage = false,
                Title = "R1.03",
                FilePath = "/images/products/3/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Title = "YAMAHA XSR900",
                Description = "This is the kind of motorcycle that you can enjoy in almost any kind of situation. It’s easy ergonomics are specially designed to give you an open and adaptable riding position that makes every ride more enjoyable. From narrow twisty backroads through to fast open corners or relaxed cruising through town, the XSR900 is ready for anything. ",
                IsActive = true,
                Price = 10199m,
                Quantity = 13
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 13,
                ProductId = 4,
                IsMainImage = true,
                Title = "XSR900.main",
                FilePath = "/images/products/4/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 14,
                ProductId = 4,
                IsMainImage = false,
                Title = "XSR900.01",
                FilePath = "/images/products/4/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 15,
                ProductId = 4,
                IsMainImage = false,
                Title = "XSR900.02",
                FilePath = "/images/products/4/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 16,
                ProductId = 4,
                IsMainImage = false,
                Title = "XSR900.03",
                FilePath = "/images/products/4/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Title = "YAMAHA NIKEN",
                Description = "The key to NIKEN GT’s outstanding handling performance is Yamaha’s LMW system. Featuring twin leaning front wheels, this innovative front end gives class leading cornering performance with enhanced feelings of stability – and it’s what makes this premium Sport Tourer one of the most capable machines in its category. ",
                IsActive = true,
                Price = 15999m,
                Quantity = 11
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 17,
                ProductId = 5,
                IsMainImage = true,
                Title = "NIKEN.main",
                FilePath = "/images/products/5/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 18,
                ProductId = 5,
                IsMainImage = false,
                Title = "NIKEN.01",
                FilePath = "/images/products/5/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 19,
                ProductId = 5,
                IsMainImage = false,
                Title = "NIKEN.02",
                FilePath = "/images/products/5/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 20,
                ProductId = 5,
                IsMainImage = false,
                Title = "NIKEN.03",
                FilePath = "/images/products/5/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Title = "HONDA CB1000R",
                Description = "Now even more stylish and aggressively muscular, just a quick glance and you catch the burnished metal finishes that reflect the tradition of a hard-charging Café Racer. ",
                IsActive = true,
                Price = 13499m,
                Quantity = 17
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 21,
                ProductId = 6,
                IsMainImage = true,
                Title = "CB1000R.main",
                FilePath = "/images/products/6/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 22,
                ProductId = 6,
                IsMainImage = false,
                Title = "CB1000R.01",
                FilePath = "/images/products/6/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 23,
                ProductId = 6,
                IsMainImage = false,
                Title = "CB1000R.02",
                FilePath = "/images/products/6/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 24,
                ProductId = 6,
                IsMainImage = false,
                Title = "CB1000R.03",
                FilePath = "/images/products/6/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Title = "HONDA CB1000RR",
                Description = "This is why we race. Why we’ve always raced, and it is feedback from HRC and our riders that’s produced the new CBR1000RR-R Fireblade. It’s got more mid-range power from intake and cylinder head upgrades, with revised gearbox ratios for incredible drive out of corners. ",
                IsActive = true,
                Price = 27899m,
                Quantity = 13
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 25,
                ProductId = 7,
                IsMainImage = true,
                Title = "CB1000RR.main",
                FilePath = "/images/products/7/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 26,
                ProductId = 7,
                IsMainImage = false,
                Title = "CB1000RR.01",
                FilePath = "/images/products/7/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 27,
                ProductId = 7,
                IsMainImage = false,
                Title = "CB1000RR.02",
                FilePath = "/images/products/7/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 28,
                ProductId = 7,
                IsMainImage = false,
                Title = "CB1000RR.03",
                FilePath = "/images/products/7/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Title = "HONDA CB750 HORNET",
                Description = "Forget the expected. It’s time for a new generation to shake things up. Start with a brand-new engine producing incredible, class-leading power. Dial in a lightweight chassis honed for sports, tightly wrapped in head-turning streetfighter style and the new CB750 Hornet takes flight. Nothing else comes close. ",
                IsActive = true,
                Price = 27899m,
                Quantity = 16
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 29,
                ProductId = 8,
                IsMainImage = true,
                Title = "CB750.main",
                FilePath = "/images/products/8/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 30,
                ProductId = 8,
                IsMainImage = false,
                Title = "CB750.01",
                FilePath = "/images/products/8/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 31,
                ProductId = 8,
                IsMainImage = false,
                Title = "CB750.02",
                FilePath = "/images/products/8/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 32,
                ProductId = 8,
                IsMainImage = false,
                Title = "CB750.03",
                FilePath = "/images/products/8/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Title = "HONDA GL1800 GOLD WING",
                Description = "The Gold Wing Tour takes care of rider and pillion alike. With dynamic handling and engine response to satisfy any rider, the pillion can settle back into their luxurious and even more expansive space and enjoy the journey ahead. ",
                IsActive = true,
                Price = 37799m,
                Quantity = 9
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 33,
                ProductId = 9,
                IsMainImage = true,
                Title = "GL1800.main",
                FilePath = "/images/products/9/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 34,
                ProductId = 9,
                IsMainImage = false,
                Title = "GL1800.01",
                FilePath = "/images/products/9/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 35,
                ProductId = 9,
                IsMainImage = false,
                Title = "GL1800.02",
                FilePath = "/images/products/9/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 36,
                ProductId = 9,
                IsMainImage = false,
                Title = "GL1800.03",
                FilePath = "/images/products/9/3.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Title = "HONDA NT1100",
                Description = "The NT1100 offers everything you need in one motorcycle. It’s built agile for the demands of the city with light, easy handling and long-travel suspension. ",
                IsActive = true,
                Price = 15499m,
                Quantity = 13
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 37,
                ProductId = 10,
                IsMainImage = true,
                Title = "NT1100.main",
                FilePath = "/images/products/10/main.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 38,
                ProductId = 10,
                IsMainImage = false,
                Title = "NT1100.01",
                FilePath = "/images/products/10/1.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 39,
                ProductId = 10,
                IsMainImage = false,
                Title = "NT1100.02",
                FilePath = "/images/products/10/2.jpg"
            });
            builder.Entity<ProductImage>().HasData(new ProductImage
            {
                Id = 40,
                ProductId = 10,
                IsMainImage = false,
                Title = "NT1100.03",
                FilePath = "/images/products/10/3.jpg"
            });
            

            base.OnModelCreating(builder);
        }
    }
}
    