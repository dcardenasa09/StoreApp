using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class PurchaseDTO : IDTO, IMapFrom {

    public int Id { get; set; }
    public string? Folio { get; set; }
    public int ClientId { get; set; }
    public DateTime Date  { get; set; }
    public decimal Total  { get; set; }
    public string? Observations  { get; set; }
    public int Status  { get; set; }
    public bool IsActive { get; set; }

    public ClientDTO? Client { get; set; }
    public List<PurchaseDetailDTO>? Details { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<Purchase, PurchaseDTO>().ReverseMap();
    }
}