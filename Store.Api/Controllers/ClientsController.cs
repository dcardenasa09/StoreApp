using Store.Entities.DTOs;
using Store.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Common.Controllers;
using Store.Api.Common.Validator;
using Store.Business.Services.Clients;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientService clientService, IValidatorHelper<ClientDTO> validator) : BaseController<Client, ClientDTO, IClientService>(clientService, validator) {
    private readonly IClientService _clientService = clientService;
}