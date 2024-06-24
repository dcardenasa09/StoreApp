using Store.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Data.Persistence.EntityConfigurations;

public class BranchStoreEntityTypeConfiguration : IEntityTypeConfiguration<BranchStore> {

	public void Configure(EntityTypeBuilder<BranchStore> builder) {

		builder.ToTable("BranchStores");
		builder.HasKey(p => p.Id);

		builder.Property(b => b.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
		builder.Property(b => b.Branch).HasColumnName("branch");
		builder.Property(b => b.Address).HasColumnName("address");
		builder.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);

		builder.HasMany(x => x.ProductStores)
			   .WithOne(x => x.BranchStore);

		builder.HasData(
            new BranchStore { Id = 1, Branch = "Sucursal Mérida", Address = "Calle 128 #321, CP 9700, Centro, Merida, Yucatan", IsActive = true }
        );
	}
}