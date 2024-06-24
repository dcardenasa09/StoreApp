using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Business.Common.Services;

namespace Store.Business.Services.Clients;

public interface IClientService: IBaseService<Client, ClientDTO> { }