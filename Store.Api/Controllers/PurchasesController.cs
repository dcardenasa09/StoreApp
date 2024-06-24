using Store.Entities.DTOs;
using Store.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Common.Controllers;
using Store.Api.Common.Validator;
using Store.Business.Services.Purchases;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchasesController(IPurchaseService purchaseService, IValidatorHelper<PurchaseDTO> validator) : BaseController<Purchase, PurchaseDTO, IPurchaseService>(purchaseService, validator) {
    private readonly IPurchaseService _purchaseService = purchaseService;

    [HttpGet("{id}/Client")]
    public async Task<IActionResult> GetByClientId([FromRoute] int id) {
        var result = await _purchaseService.GetByClientId(id);
        return Ok(result);
    }

    [HttpGet("{id}/Detail")]
    public async Task<IActionResult> GetDetail([FromRoute] int id) {
        var result = await _purchaseService.GetDetail(id);
        return Ok(result);
    }

    [HttpPost("Detail")]
    public async Task<IActionResult> AddDetail([FromBody] PurchaseDetailDTO detail) {
        var result = await _purchaseService.AddDetail(detail);
        return Ok(result);
    }

    [HttpDelete("{id}/Detail")]
    public async Task<IActionResult> RemoveDetail([FromRoute] int id) {
        var result = await _purchaseService.RemoveDetail(id);
        return Ok(result);
    }
}