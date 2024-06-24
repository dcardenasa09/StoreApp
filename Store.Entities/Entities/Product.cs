using Store.Entities.Common.Interfaces;

namespace Store.Entities.Entities;

public class Product : IEntity {

    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? UrlImage  { get; set; }
    public int Stock  { get; set; }
    public bool IsActive { get; set; }

    public virtual List<ProductStore>? ProductStores { get; set; }
}