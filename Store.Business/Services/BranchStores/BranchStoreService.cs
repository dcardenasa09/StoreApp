using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Business.Common.Services;
using Store.Data.Repositories.BranchStores;

namespace Store.Business.Services.BranchStores;

public class BranchStoreService : BaseService<BranchStore, BranchStoreDTO, IBranchStoreRepository>, IBranchStoreService {

    private readonly IMapper _mapper;
    private readonly IBranchStoreRepository _branchStoreRepository;

    public BranchStoreService (IMapper mapper, IBranchStoreRepository branchStoreRepository) : base(mapper, branchStoreRepository) {
        _mapper                = mapper;
        _branchStoreRepository = branchStoreRepository; 
    }
}