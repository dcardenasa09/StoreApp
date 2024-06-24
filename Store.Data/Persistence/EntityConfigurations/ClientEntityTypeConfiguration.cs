using Store.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Data.Persistence.EntityConfigurations;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client> {

	public void Configure(EntityTypeBuilder<Client> builder) {

		builder.ToTable("Clients");
		builder.HasKey(p => p.Id);

		builder.Property(b => b.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
		builder.Property(b => b.Name).HasColumnName("name").IsRequired();
		builder.Property(b => b.LastName).HasColumnName("last_name").IsRequired();
		builder.Property(b => b.Phone).HasColumnName("phone").IsRequired();
		builder.Property(b => b.Email).HasColumnName("email").IsRequired();
		builder.Property(b => b.Address).HasColumnName("address");
		builder.Property(b => b.IsActive).HasColumnName("is_active").HasDefaultValue(true);

		builder.HasMany(x => x.Purchases)
			   .WithOne(x => x.Client);
	}
}