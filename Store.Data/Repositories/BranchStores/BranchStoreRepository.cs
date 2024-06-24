using Store.Data.Persistence;
using Store.Entities.Entities;
using Store.Data.Common.Repositories;

namespace Store.Data.Repositories.BranchStores;

public class BranchStoreRepository(StoreDbContext context) : BaseRepository<BranchStore>(context), IBranchStoreRepository {
    private readonly StoreDbContext _context = context;
}