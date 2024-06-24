using Store.Data.Persistence;
using Store.Entities.Entities;
using Store.Data.Common.Repositories;

namespace Store.Data.Repositories.Products;

public class ProductRepository(StoreDbContext context) : BaseRepository<Product>(context), IProductRepository {
    private readonly StoreDbContext _context = context;
}