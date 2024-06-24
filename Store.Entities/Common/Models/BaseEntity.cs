using Store.Entities.Common.Interfaces;

namespace Store.Entities.Common.Models;

public abstract class BaseEntity: IDTO {
    public int Id { get; set; }
}