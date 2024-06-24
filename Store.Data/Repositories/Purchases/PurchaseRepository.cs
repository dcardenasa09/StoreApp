using Store.Data.Persistence;
using Store.Entities.Entities;
using Store.Data.Common.Repositories;

namespace Store.Data.Repositories.Purchases;

public class PurchaseRepository(StoreDbContext context) : BaseRepository<Purchase>(context), IPurchaseRepository {
    private readonly StoreDbContext _context = context;
}