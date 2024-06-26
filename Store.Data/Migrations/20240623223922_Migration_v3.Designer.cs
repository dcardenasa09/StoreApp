﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data.Persistence;

#nullable disable

namespace Store.Data.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20240623223922_Migration_v3")]
    partial class Migration_v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Store.Entities.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Store.Entities.Entities.BranchStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("branch");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.HasKey("Id");

                    b.ToTable("BranchStores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Calle 128 #321, CP 9700, Centro, Merida, Yucatan",
                            Branch = "Sucursal Mérida",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Store.Entities.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Store.Entities.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("key");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_image");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Producto 1",
                            IsActive = true,
                            Key = "PROD1",
                            Price = 19.99m,
                            Stock = 100,
                            UrlImage = "image1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Producto 2",
                            IsActive = true,
                            Key = "PROD2",
                            Price = 29.99m,
                            Stock = 50,
                            UrlImage = "image2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Producto 3",
                            IsActive = true,
                            Key = "PROD3",
                            Price = 39.99m,
                            Stock = 200,
                            UrlImage = "image3.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Producto 4",
                            IsActive = true,
                            Key = "PROD4",
                            Price = 29.99m,
                            Stock = 150,
                            UrlImage = "image4.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Producto 5",
                            IsActive = true,
                            Key = "PROD5",
                            Price = 29.99m,
                            Stock = 150,
                            UrlImage = "image5.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Producto 6",
                            IsActive = true,
                            Key = "PROD6",
                            Price = 59.99m,
                            Stock = 20,
                            UrlImage = "image6.jpg"
                        });
                });

            modelBuilder.Entity("Store.Entities.Entities.ProductStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchStoreId")
                        .HasColumnType("int")
                        .HasColumnName("branch_store_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("BranchStoreId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductStores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BranchStoreId = 1,
                            Date = new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8057),
                            IsActive = true,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            BranchStoreId = 1,
                            Date = new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8069),
                            IsActive = true,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            BranchStoreId = 1,
                            Date = new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8070),
                            IsActive = true,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            BranchStoreId = 1,
                            Date = new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8071),
                            IsActive = true,
                            ProductId = 4
                        },
                        new
                        {
                            Id = 5,
                            BranchStoreId = 1,
                            Date = new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8072),
                            IsActive = true,
                            ProductId = 5
                        },
                        new
                        {
                            Id = 6,
                            BranchStoreId = 1,
                            Date = new DateTime(2024, 6, 23, 16, 39, 21, 744, DateTimeKind.Local).AddTicks(8073),
                            IsActive = true,
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("Store.Entities.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc))
                        .HasColumnName("date");

                    b.Property<string>("Folio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("folio");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("observations");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Purchases", (string)null);
                });

            modelBuilder.Entity("Store.Entities.Entities.PurchaseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("price");

                    b.Property<int>("ProductStoreId")
                        .HasColumnType("int")
                        .HasColumnName("product_store_id");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int")
                        .HasColumnName("purchase_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasIndex("ProductStoreId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetails", (string)null);
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
                    b.HasOne("Store.Entities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Store.Entities.Entities.ApplicationUser", null)
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

                    b.HasOne("Store.Entities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Store.Entities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Store.Entities.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Store.Entities.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Store.Entities.Entities.ProductStore", b =>
                {
                    b.HasOne("Store.Entities.Entities.BranchStore", "BranchStore")
                        .WithMany("ProductStores")
                        .HasForeignKey("BranchStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Entities.Entities.Product", "Product")
                        .WithMany("ProductStores")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchStore");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Store.Entities.Entities.Purchase", b =>
                {
                    b.HasOne("Store.Entities.Entities.Client", "Client")
                        .WithMany("Purchases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Store.Entities.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("Store.Entities.Entities.ProductStore", "ProductStore")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("ProductStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Entities.Entities.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductStore");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Store.Entities.Entities.BranchStore", b =>
                {
                    b.Navigation("ProductStores");
                });

            modelBuilder.Entity("Store.Entities.Entities.Client", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Store.Entities.Entities.Product", b =>
                {
                    b.Navigation("ProductStores");
                });

            modelBuilder.Entity("Store.Entities.Entities.ProductStore", b =>
                {
                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("Store.Entities.Entities.Purchase", b =>
                {
                    b.Navigation("PurchaseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
