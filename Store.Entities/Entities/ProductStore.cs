using Store.Entities.Common.Interfaces;

namespace Store.Entities.Entities;

public class ProductStore : IEntity {

    public int Id { get; set; }
    public int ProductId { get; set; }
    public int BranchStoreId { get; set; }
    public DateTime Date  { get; set; }
    public bool IsActive { get; set; }

    public virtual Product? Product { get; set; }
    public virtual BranchStore? BranchStore { get; set; }
    public virtual List<PurchaseDetail>? PurchaseDetails { get; set; }
}