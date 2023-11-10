﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motorcycle_WebShop.Data;

#nullable disable

namespace Motorcycle_WebShop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4bc6d9be - 018d - 4cd9 - acaa - d855942ee8d9",
                            Name = "Chief executive officer",
                            NormalizedName = "CHIEF EXECUTIVE OFFICER"
                        },
                        new
                        {
                            Id = "811bf54e-ec17-457f-917b-c432d1060070",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = "edffea81-92bf-4400-84f3-047a9f72cbc7",
                            Name = "Support",
                            NormalizedName = "SUPPORT"
                        },
                        new
                        {
                            Id = "2cd04bd9-83ff-49a3-a1b7-e97a5e9896d9",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "94a721f8-f477-40f7-aec2-057742da1c26",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Motorcycle_WebShop.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AvatarFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastKnownIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BillingCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BillingCountry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BillingEmail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BillingFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BillingLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BillingPhone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("BillingPostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ShippingCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ShippingCountry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ShippingEmail")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ShippingFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShippingLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShippingPhone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ShippingPostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Kada je Yamaha prije desetak godina predstavila prvi model MT iz asortimana Hyper Naked, svijet motocikla zauvijek se promijenio. Uz jasnu usredotočenost na okretni moment, okretnost i osjećaj, asortiman modela MT vozačima je pružio mogućnost da dožive sirove emocije i uzbuđenje na zahtjev koji svaki Hyper Naked model čine posebnim.",
                            IsActive = true,
                            Price = 15199m,
                            Quantity = 14m,
                            Title = "YAMAHA MT-10"
                        },
                        new
                        {
                            Id = 2,
                            Description = "U 2015. prvi je TRACER 900 zauvijek promijenio klasu sportskih krstarica. Uz svoj CP3 agregat velikog okretnog momenta, sportsko podvozje i izvanrednu svestranost, Tracer 900 je bio odabir više od 50.000 europskih vozača koji žele okretan i uzbudljiv višenamjenski motocikl s puno stava. Možda i nije iznenađenje što je to najprodavaniji motocikl u klasi.",
                            IsActive = true,
                            Price = 16499m,
                            Quantity = 10m,
                            Title = "YAMAHA TRACER 9"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Model R1 najusredotočeniji je i najsuvremeniji motocikl kategorije Supersport kojeg je Yamaha ikada napravila, sve od predstavljanja originalnog modela prije više od 25 godina. Gotovo sve na najnovijem modelu R1 ima svoje izravno podrijetlo na trkalištu, gdje su Yamahine tvorničke trkaće momčadi i probni vozači razvijali i testirali naprednu tehnologiju koju sada možete vidjeti i isprobati na svom modelu R1.",
                            IsActive = true,
                            Price = 17399m,
                            Quantity = 21m,
                            Title = "YAMAHA R1"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Ovo je motocikl na kojem možete uživati u gotovo svakoj situaciji. Njegova jednostavna ergonomija posebno je dizajnirana kako bi vam pružila otvoren i prilagodljiv položaj za vožnju koji svaku vožnju čini ugodnijom. Od uskih zavojitih uličica do brzih otvorenih zavoja ili opuštenog krstarenja gradom, XSR900 spreman je na sve. ",
                            IsActive = true,
                            Price = 10199m,
                            Quantity = 13m,
                            Title = "YAMAHA XSR900"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Ključ iznimnih sportskih i putnih performansi modela NIKEN njegov je naprednom tehnologijom izrađen prednji kraj. Ovaj jedinstveni dizajn s dva nagibna prednja kotača ima veliku dodirnu površinu s cestom, čime pruža brojne prednosti. ",
                            IsActive = true,
                            Price = 15999m,
                            Quantity = 11m,
                            Title = "YAMAHA NIKEN"
                        });
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsMainImage")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FilePath = "/images/products/1/main.jpg",
                            IsMainImage = true,
                            ProductId = 1,
                            Title = "MT-10.main"
                        },
                        new
                        {
                            Id = 2,
                            FilePath = "/images/products/1/1.jpg",
                            IsMainImage = false,
                            ProductId = 1,
                            Title = "MT-10.01"
                        },
                        new
                        {
                            Id = 3,
                            FilePath = "/images/products/1/2.jpg",
                            IsMainImage = false,
                            ProductId = 1,
                            Title = "MT-10.02"
                        },
                        new
                        {
                            Id = 4,
                            FilePath = "/images/products/1/3.jpg",
                            IsMainImage = false,
                            ProductId = 1,
                            Title = "MT-10.03"
                        },
                        new
                        {
                            Id = 5,
                            FilePath = "/images/products/2/main.jpg",
                            IsMainImage = true,
                            ProductId = 2,
                            Title = "TRACER 9.main"
                        },
                        new
                        {
                            Id = 6,
                            FilePath = "/images/products/2/1.jpg",
                            IsMainImage = false,
                            ProductId = 2,
                            Title = "TRACER 9.01"
                        },
                        new
                        {
                            Id = 7,
                            FilePath = "/images/products/2/2.jpg",
                            IsMainImage = false,
                            ProductId = 2,
                            Title = "TRACER 9.02"
                        },
                        new
                        {
                            Id = 8,
                            FilePath = "/images/products/2/3.jpg",
                            IsMainImage = false,
                            ProductId = 2,
                            Title = "TRACER 9.03"
                        },
                        new
                        {
                            Id = 9,
                            FilePath = "/images/products/3/main.jpg",
                            IsMainImage = true,
                            ProductId = 3,
                            Title = "R1.main"
                        },
                        new
                        {
                            Id = 10,
                            FilePath = "/images/products/3/1.jpg",
                            IsMainImage = false,
                            ProductId = 3,
                            Title = "R1.01"
                        },
                        new
                        {
                            Id = 11,
                            FilePath = "/images/products/3/2.jpg",
                            IsMainImage = false,
                            ProductId = 3,
                            Title = "R1.02"
                        },
                        new
                        {
                            Id = 12,
                            FilePath = "/images/products/3/3.jpg",
                            IsMainImage = false,
                            ProductId = 3,
                            Title = "R1.03"
                        },
                        new
                        {
                            Id = 13,
                            FilePath = "/images/products/4/main.jpg",
                            IsMainImage = true,
                            ProductId = 4,
                            Title = "XSR900.main"
                        },
                        new
                        {
                            Id = 14,
                            FilePath = "/images/products/4/1.jpg",
                            IsMainImage = false,
                            ProductId = 4,
                            Title = "XSR900.01"
                        },
                        new
                        {
                            Id = 15,
                            FilePath = "/images/products/4/2.jpg",
                            IsMainImage = false,
                            ProductId = 4,
                            Title = "XSR900.02"
                        },
                        new
                        {
                            Id = 16,
                            FilePath = "/images/products/4/3.jpg",
                            IsMainImage = false,
                            ProductId = 4,
                            Title = "XSR900.03"
                        },
                        new
                        {
                            Id = 17,
                            FilePath = "/images/products/5/main.jpg",
                            IsMainImage = true,
                            ProductId = 5,
                            Title = "NIKEN.main"
                        },
                        new
                        {
                            Id = 18,
                            FilePath = "/images/products/5/1.jpg",
                            IsMainImage = false,
                            ProductId = 5,
                            Title = "NIKEN.01"
                        },
                        new
                        {
                            Id = 19,
                            FilePath = "/images/products/5/2.jpg",
                            IsMainImage = false,
                            ProductId = 5,
                            Title = "NIKEN.02"
                        },
                        new
                        {
                            Id = 20,
                            FilePath = "/images/products/5/3.jpg",
                            IsMainImage = false,
                            ProductId = 5,
                            Title = "NIKEN.03"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Motorcycle_WebShop.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Order", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Data.ApplicationUser", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.OrderItem", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Motorcycle_WebShop.Models.Product", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.ProductCategory", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Models.Category", null)
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Motorcycle_WebShop.Models.Product", null)
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.ProductImage", b =>
                {
                    b.HasOne("Motorcycle_WebShop.Models.Product", null)
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Motorcycle_WebShop.Data.ApplicationUser", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Motorcycle_WebShop.Models.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
