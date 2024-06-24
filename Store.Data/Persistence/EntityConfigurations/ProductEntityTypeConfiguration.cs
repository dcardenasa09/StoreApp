using Store.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Data.Persistence.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product> {

	public void Configure(EntityTypeBuilder<Product> builder) {

		builder.ToTable("Products");
		builder.HasKey(p => p.Id);

		builder.Property(b => b.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
		builder.Property(b => b.Key).HasColumnName("key");
		builder.Property(b => b.Description).HasColumnName("description");
		builder.Property(b => b.Price).HasColumnName("price");
		builder.Property(b => b.UrlImage).HasColumnName("url_image");
		builder.Property(b => b.Stock).HasColumnName("stock");
		builder.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);

		builder.HasMany(x => x.ProductStores)
			   .WithOne(x => x.Product);

		builder.HasData(
            new Product { Id = 1, Key = "PROD1", Description = "Producto 1", Price = 19.99m, UrlImage = "image1.jpg", Stock = 100, IsActive = true },
            new Product { Id = 2, Key = "PROD2", Description = "Producto 2", Price = 29.99m, UrlImage = "image2.jpg", Stock = 50,  IsActive = true },
            new Product { Id = 3, Key = "PROD3", Description = "Producto 3", Price = 39.99m, UrlImage = "image3.jpg", Stock = 200, IsActive = true },
            new Product { Id = 4, Key = "PROD4", Description = "Producto 4", Price = 29.99m, UrlImage = "image4.jpg", Stock = 150, IsActive = true },
            new Product { Id = 5, Key = "PROD5", Description = "Producto 5", Price = 29.99m, UrlImage = "image5.jpg", Stock = 150, IsActive = true },
            new Product { Id = 6, Key = "PROD6", Description = "Producto 6", Price = 59.99m, UrlImage = "image6.jpg", Stock = 20, IsActive = true }
        );
	}
}