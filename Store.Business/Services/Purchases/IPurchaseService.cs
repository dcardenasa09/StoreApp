using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Business.Common.Services;

namespace Store.Business.Services.Purchases;

public interface IPurchaseService: IBaseService<Purchase, PurchaseDTO> {

    Task<PurchaseDTO> GetByClientId(int clientId);
    Task<List<PurchaseDetailDTO>> GetDetail(int purchaseId);
    Task<PurchaseDetailDTO> AddDetail(PurchaseDetailDTO detail);
    Task<bool> RemoveDetail(int id);
}