using AutoMapper;
using Store.Entities.DTOs;
using Store.Entities.Enums;
using Store.Entities.Entities;
using Store.Business.Common.Services;
using Store.Data.Repositories.Purchases;
using Store.Business.Common.Helpers;
using Store.Data.Repositories.Products;
using System.Linq.Expressions;

namespace Store.Business.Services.Purchases;

public class PurchaseService(IMapper mapper, IPurchaseRepository purchaseRepository, IPurchaseDetailRepository purchaseDetailRepository, IProductRepository productRepository) : BaseService<Purchase, PurchaseDTO, IPurchaseRepository>(mapper, purchaseRepository), IPurchaseService {

    private readonly IMapper _mapper = mapper;
    private readonly IPurchaseRepository _purchaseRepository = purchaseRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IPurchaseDetailRepository _purchaseDetailRepository = purchaseDetailRepository;

    public override Task<List<PurchaseDTO>> GetList(Expression<Func<Purchase, bool>> predicate, string[]? includes = null, bool applyAsNoTracking = true) {
        return base.GetList(x => x.Status != (int)PurchaseStatusEnum.Pendant, includes, applyAsNoTracking);
    }

    public async Task<PurchaseDTO> GetByClientId(int clientId) {
        Purchase? response = await _purchaseRepository.GetFirst(x => x.ClientId == clientId
                                                                    && x.Status == (int)PurchaseStatusEnum.Pendant, null, false);

        response ??= await CreatePurchase(clientId);
        return _mapper.Map<PurchaseDTO>(response);
    }

    public override async Task Delete(int purchaseId) {
        Purchase entity = await _purchaseRepository.GetById(purchaseId);
        if(entity != null) {
            entity.Status = (int)PurchaseStatusEnum.Canceled;

            await ChangesStock(purchaseId, true);
            await _purchaseRepository.Update(entity);
        }
    }

    public async Task<Purchase> CreatePurchase(int clientId) {
        Purchase? purchase = new() {
            Id           = 0,
            Folio        = "",
            ClientId     = clientId,
            Date         = DateTime.Now,
            Status       = (int)PurchaseStatusEnum.Pendant,
            Total        = 0,
            Observations = "",
            IsActive     = true
        };

        return await _purchaseRepository.Create(purchase);
    }

    public override async Task<PurchaseDTO> Update(PurchaseDTO dto) {
        dto.Folio  = await GetFolio();
        dto.Date   = DateTime.Now;
        dto.Status = (int)PurchaseStatusEnum.Completed;

        await ChangesStock(dto.Id);
        await _purchaseRepository.Update(_mapper.Map<Purchase>(dto));
        return dto;
    }

    private async Task ChangesStock(int purchaseId, bool isCanceled = false) {
        var includes = IncludesHelper.GetIncludes<PurchaseDetail>(x => x.ProductStore, x => x.ProductStore.Product);
        List<PurchaseDetail> details = await _purchaseDetailRepository.GetList(x => x.PurchaseId == purchaseId, includes);

        if(details.Count > 0) {
            foreach (var item in details) {
                if(item.ProductStore != null && item.ProductStore.Product != null) {
                    var product = item.ProductStore.Product;
                    product.Stock = (!isCanceled) ? (product.Stock - item.Quantity) : (product.Stock + item.Quantity);
                    await _productRepository.Update(product);
                }
            }
        }
    }

    public async Task<List<PurchaseDetailDTO>> GetDetail(int purchaseId) {
        var include = IncludesHelper.GetIncludes<PurchaseDetail>(x => x.ProductStore, x => x.ProductStore.Product);
        var response = await _purchaseDetailRepository.GetList(x => x.PurchaseId == purchaseId, include);

        return _mapper.Map<List<PurchaseDetailDTO>>(response);
    }

    public async Task<PurchaseDetailDTO> AddDetail(PurchaseDetailDTO detail) {
        var validate = await _purchaseDetailRepository.GetFirst(x => x.ProductStoreId == detail.ProductStoreId 
                                                                  && x.PurchaseId == detail.PurchaseId, null, false);

        if(validate != null) {
            validate.Quantity += detail.Quantity;
            validate.Total = validate.Quantity * validate.Price;

            await _purchaseDetailRepository.Update(validate);
        } else {
            var response = await _purchaseDetailRepository.Create(_mapper.Map<PurchaseDetail>(detail));
        }

        return _mapper.Map<PurchaseDetailDTO>(detail);
    }

    public async Task<bool> RemoveDetail(int id) {
        return await _purchaseDetailRepository.Delete(id);
    }

    private async Task<string> GetFolio() {
       	int numero = 1;

		List<Purchase> purcheses = await _purchaseRepository.GetList(x => x.IsActive
                                                                       && x.Status == (int)PurchaseStatusEnum.Completed);

        if (purcheses.Count > 0) {
            var purchase = purcheses.OrderByDescending(x => x.Date).First();

            var x  = purchase.Folio?.Split("PUR-", ',');
            numero = Convert.ToInt32(x?[1]) + 1;
        }

        string folio = string.Format("PUR-{0}", numero);
        return folio;
    }
}