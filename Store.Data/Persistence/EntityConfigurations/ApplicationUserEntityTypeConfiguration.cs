// using Store.Entities.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace Store.Data.Persistence.EntityConfigurations;

// public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser> {

// 	public void Configure(EntityTypeBuilder<ApplicationUser> builder) {

// 		builder.ToTable("Users");

// 		builder.HasData(
//             new ApplicationUser{
// 				Id                 = "1",
// 				UserName           = "admin@example.com",
// 				NormalizedUserName = "ADMIN@EXAMPLE.COM", 
// 				Email              = "admin@example.com",
// 				NormalizedEmail    = "ADMIN@EXAMPLE.COM",
// 				PasswordHash       = "hashed_password_here",
// 				SecurityStamp      = string.Empty,
// 				EmailConfirmed     = true,
// 				IsAdmin            = true
// 			}
//         );
// 	}
// }