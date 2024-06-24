using Store.Entities.Common.Interfaces;

namespace Store.Entities.Entities;

public class Purchase : IEntity {

    public int Id { get; set; }
    public string? Folio { get; set; }
    public int ClientId { get; set; }
    public DateTime Date  { get; set; }
    public decimal Total  { get; set; }
    public int Status  { get; set; }
    public string? Observations  { get; set; }
    public bool IsActive { get; set; }

    public virtual Client? Client { get; set; }
    public virtual List<PurchaseDetail>? PurchaseDetails { get; set; }
}