using Store.Entities.Common.Interfaces;

namespace Store.Entities.Entities;

public class Client : IEntity {

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Phone  { get; set; }
    public string? Email  { get; set; }
    public string? Address  { get; set; }
    public bool IsActive { get; set; }

    public virtual List<Purchase>? Purchases { get; set; }

    public string GetFullName() {
        return $"{Name} {LastName}";
    }
}