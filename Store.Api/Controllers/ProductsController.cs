using Store.Entities.DTOs;
using Store.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Common.Controllers;
using Store.Api.Common.Validator;
using Store.Business.Services.Products;
using Microsoft.AspNetCore.Authorization;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService, IValidatorHelper<ProductDTO> validator) : BaseController<Product, ProductDTO, IProductService>(productService, validator) {
    private readonly IProductService _productService = productService;

    [AllowAnonymous]
    [HttpGet("ProductsStore")]
    public async Task<IActionResult> GetProductsStore([FromQuery] int branchStoreId) {
        var result = await _productService.GetProductsStore(branchStoreId);
        return Ok(result);
    }
}