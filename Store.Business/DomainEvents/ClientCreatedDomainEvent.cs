using MediatR;

namespace Store.Business.DomainEvents;

public class ClientCreatedDomainEvent(int clientId) : INotification {

    public int ClientId { get; set; } = clientId;
}