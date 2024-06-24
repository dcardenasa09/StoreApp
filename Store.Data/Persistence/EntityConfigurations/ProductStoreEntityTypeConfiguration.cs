using Store.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Data.Persistence.EntityConfigurations;

public class ProductStoreEntityTypeConfiguration : IEntityTypeConfiguration<ProductStore> {

	public void Configure(EntityTypeBuilder<ProductStore> builder) {

		builder.ToTable("ProductStores");
		builder.HasKey(p => p.Id);

		builder.Property(b => b.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
		builder.Property(b => b.BranchStoreId).HasColumnName("branch_store_id");
		builder.Property(b => b.ProductId).HasColumnName("product_id");
		builder.Property(b => b.Date).HasColumnName("date");
		builder.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);

		builder.HasOne(x => x.BranchStore)
			   .WithMany(x => x.ProductStores)
			   .HasForeignKey(x => x.BranchStoreId);

		builder.HasOne(x => x.Product)
			   .WithMany(x => x.ProductStores)
			   .HasForeignKey(x => x.ProductId);

		builder.HasMany(x => x.PurchaseDetails)
			   .WithOne(x => x.ProductStore);
			   
		builder.HasData(
            new ProductStore { Id = 1, BranchStoreId = 1, ProductId = 1, Date = DateTime.Now, IsActive = true },
            new ProductStore { Id = 2, BranchStoreId = 1, ProductId = 2, Date = DateTime.Now, IsActive = true },
            new ProductStore { Id = 3, BranchStoreId = 1, ProductId = 3, Date = DateTime.Now, IsActive = true },
            new ProductStore { Id = 4, BranchStoreId = 1, ProductId = 4, Date = DateTime.Now, IsActive = true },
            new ProductStore { Id = 5, BranchStoreId = 1, ProductId = 5, Date = DateTime.Now, IsActive = true },
            new ProductStore { Id = 6, BranchStoreId = 1, ProductId = 6, Date = DateTime.Now, IsActive = true }
        );
	}
}