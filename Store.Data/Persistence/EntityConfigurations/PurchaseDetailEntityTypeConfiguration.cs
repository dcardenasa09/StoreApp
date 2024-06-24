using Store.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Data.Persistence.EntityConfigurations;

public class PurchaseDetailEntityTypeConfiguration : IEntityTypeConfiguration<PurchaseDetail> {

	public void Configure(EntityTypeBuilder<PurchaseDetail> builder) {

		builder.ToTable("PurchaseDetails");
		builder.HasKey(p => p.Id);

		builder.Property(b => b.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
		builder.Property(b => b.PurchaseId).HasColumnName("purchase_id").IsRequired();
		builder.Property(b => b.ProductStoreId).HasColumnName("product_store_id").IsRequired();
		builder.Property(b => b.Quantity).HasColumnName("quantity");
		builder.Property(b => b.Price).HasColumnName("price").HasColumnType("decimal(18, 2)");
		builder.Property(b => b.Total).HasColumnName("Total").HasColumnType("decimal(18, 2)");
		builder.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);

		builder.HasOne(x => x.Purchase)
			   .WithMany(x => x.PurchaseDetails)
			   .HasForeignKey(x => x.PurchaseId);

		builder.HasOne(x => x.ProductStore)
			   .WithMany(x => x.PurchaseDetails)
			   .HasForeignKey(x => x.ProductStoreId);
	}
}