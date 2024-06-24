using Store.Data.Persistence;
using Store.Entities.Entities;
using Store.Data.Common.Repositories;

namespace Store.Data.Repositories.Purchases;

public class PurchaseDetailRepository(StoreDbContext context) : BaseRepository<PurchaseDetail>(context), IPurchaseDetailRepository {
    private readonly StoreDbContext _context = context;
}