using Microsoft.AspNetCore.Identity;

namespace Store.Entities.Entities;

public class ApplicationUser : IdentityUser {

    public int? ClientId { get; set; }
    public bool IsAdmin { get; set; }

    public virtual Client? Client { get; set; }
}