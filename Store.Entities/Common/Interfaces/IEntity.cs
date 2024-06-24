namespace Store.Entities.Common.Interfaces;

public interface IEntity {
    public int Id { get; set; }
    public bool IsActive { get; set; }
}