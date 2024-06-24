using Store.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Data.Persistence.EntityConfigurations;

public class PurchaseEntityTypeConfiguration : IEntityTypeConfiguration<Purchase> {

	public void Configure(EntityTypeBuilder<Purchase> builder) {

		builder.ToTable("Purchases");
		builder.HasKey(p => p.Id);

		builder.Property(b => b.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
		builder.Property(b => b.Folio).HasColumnName("folio").IsRequired();
		builder.Property(b => b.ClientId).HasColumnName("client_id").IsRequired();
		builder.Property(b => b.Date).HasColumnName("date").HasDefaultValue(DateTime.MinValue.ToUniversalTime());
		builder.Property(b => b.Total).HasColumnName("total").HasColumnType("decimal(18, 2)");
		builder.Property(b => b.Observations).HasColumnName("observations");
		builder.Property(b => b.Status).HasColumnName("status");
		builder.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);

		builder.HasOne(x => x.Client)
			   .WithMany(x => x.Purchases)
			   .HasForeignKey(x => x.ClientId);
			
		builder.HasMany(x => x.PurchaseDetails)
			   .WithOne(x => x.Purchase);
	}
}