using Store.Entities.DTOs;
using Store.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Common.Controllers;
using Store.Api.Common.Validator;
using Store.Business.Services.BranchStores;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchStoresController(IBranchStoreService branchStoreService, IValidatorHelper<BranchStoreDTO> validator) : BaseController<BranchStore, BranchStoreDTO, IBranchStoreService>(branchStoreService, validator) {
    private readonly IBranchStoreService _branchStoreService = branchStoreService;
}