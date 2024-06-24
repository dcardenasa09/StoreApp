using Store.Entities.Common.Interfaces;

namespace Store.Entities.Entities;

public class BranchStore : IEntity {

    public int Id { get; set; }
    public string? Branch { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }

    public virtual List<ProductStore>? ProductStores { get; set; }
}