using AutoMapper;
using System.Linq.Expressions;
using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Business.Common.Services;
using Store.Business.Common.Exceptions;
using Store.Data.Repositories.Products;
using Store.Data.Repositories.Purchases;
using Store.Business.Common.Helpers;

namespace Store.Business.Services.Products;

public class ProductService(IMapper mapper, IProductRepository productRepository, IPurchaseDetailRepository purchaseDetailRepository) : BaseService<Product, ProductDTO, IProductRepository>(mapper, productRepository), IProductService {

    private readonly IMapper _mapper = mapper;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<List<ProductDTO>> GetProductsStore(int branchStoreId = 1) {
        var include = IncludesHelper.GetIncludes<Product>(x => x.ProductStores);
        List<Product>? products = await _productRepository.GetList(x => x.ProductStores != null && x.ProductStores.Any(y => y.BranchStoreId == branchStoreId), include);

        return products.Count > 0 ? _mapper.Map<List<ProductDTO>>(products) : [];
    }

    private List<ProductDTO> MapToProductDTO(List<Product> products) {
        List<ProductDTO> productDTO = [];

        foreach (var item in products) {
            ProductDTO obj = new() {
                Id            = item.Id,
                Key           = item.Key,
                Description   = item.Description,
                Price         = item.Price,
                UrlImage      = item.UrlImage, 
                Stock         = item.Stock, 
                IsActive      = item.IsActive,
            };

            productDTO.Add(obj);
        }

        return productDTO;
    }
}