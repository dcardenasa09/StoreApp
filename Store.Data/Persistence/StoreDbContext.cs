using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Entities.Entities;
using Store.Data.Persistence.EntityConfigurations;

namespace Store.Data.Persistence;

public class StoreDbContext : IdentityDbContext<ApplicationUser> {

	public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

	public virtual DbSet<BranchStore>? BranchStores { get; set; }
	public virtual DbSet<Client>? Clients { get; set; }
	public virtual DbSet<Product>? Products { get; set; }
	public virtual DbSet<ProductStore>? ProductStores { get; set; }
	public virtual DbSet<Purchase>? Purchases { get; set; }
	public virtual DbSet<PurchaseDetail>? PurchaseDetails { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfiguration(new BranchStoreEntityTypeConfiguration());
		modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
		modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
		modelBuilder.ApplyConfiguration(new ProductStoreEntityTypeConfiguration());
		modelBuilder.ApplyConfiguration(new PurchaseEntityTypeConfiguration());
		modelBuilder.ApplyConfiguration(new PurchaseDetailEntityTypeConfiguration());
	}
}
