using AutoMapper;
using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Entities.Common.Models;
using Store.Business.Common.Services;
using Store.Data.Repositories.Clients;
using Microsoft.EntityFrameworkCore;

namespace Store.Business.Services.Clients;

public class ClientService : BaseService<Client, ClientDTO, IClientRepository>, IClientService {

    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;

    public ClientService (IMapper mapper, IClientRepository clientRepository) : base(mapper, clientRepository) {
        _mapper           = mapper;
        _clientRepository = clientRepository; 
    }
}