using Store.Data.Persistence;
using Store.Entities.Entities;
using Store.Data.Common.Repositories;

namespace Store.Data.Repositories.Clients;

public class ClientRepository(StoreDbContext context) : BaseRepository<Client>(context), IClientRepository {
    private readonly StoreDbContext _context = context;
}