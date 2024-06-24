using MediatR;
using Store.Entities.Enums;
using Store.Entities.Entities;
using Store.Business.DomainEvents;
using Store.Data.Repositories.Purchases;

namespace Store.Business.DomainEvents;

public class ClientCreatedDomainEventHandler(IPurchaseRepository purchaseRepository) : INotificationHandler<ClientCreatedDomainEvent> {

    private readonly IPurchaseRepository _purchaseRepository = purchaseRepository;

    public async Task Handle(ClientCreatedDomainEvent notification, CancellationToken cancellationToken) {
        Purchase? purchase = new() {
            Folio        = await GetFolio(),
            ClientId     = notification.ClientId,
            Date         = DateTime.Now,
            Status       = (int)PurchaseStatusEnum.Pendant,
            Total        = 0,
            Observations = "",
            IsActive     = true
        };
        
        await _purchaseRepository.Create(purchase);
    }

    private async Task<string> GetFolio() {
       	int numero = 1;

		List<Purchase> transactions = await _purchaseRepository.GetList(x => x.IsActive);
        if (transactions.Count > 0) {
            var transaction = transactions.OrderByDescending(x => x.Date).First();

            var x  = transaction.Folio?.Split("PUR-", ',');
            numero = Convert.ToInt32(x?[1]) + 1;
        }

        string folio = string.Format("PUR-{0}", numero);
        return folio;
    }
}