using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Business.Common.Services;

namespace Store.Business.Services.Products;

public interface IProductService: IBaseService<Product, ProductDTO> {
    Task<List<ProductDTO>> GetProductsStore(int branchStoreId = 1);
}