using Store.Entities.Common.Interfaces;

namespace Store.Entities.Entities;

public class PurchaseDetail : IEntity {
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public int ProductStoreId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public bool IsActive { get; set; }

    public virtual Purchase? Purchase { get; set; }
    public virtual ProductStore? ProductStore { get; set; }
}