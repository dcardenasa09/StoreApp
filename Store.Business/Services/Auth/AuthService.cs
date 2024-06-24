using MediatR;
using System.Security.Claims;
using System.Text;
using Store.Data.Persistence;
using Store.Entities.Entities;
using Store.Entities.Common.Models;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Repositories.Clients;
using Store.Business.DomainEvents;
using Store.Entities.DTOs;

namespace Store.Business.Services.Auth;

public class AuthService(UserManager<ApplicationUser> userManager, 
                         SignInManager<ApplicationUser> signInManager,
                         IClientRepository clientRepository,
                         StoreDbContext context, 
                         IMediator mediator,
                         IConfiguration configuration) : IAuthService {

    private readonly IMediator _mediator = mediator;
    private readonly StoreDbContext _context = context;
    private readonly IConfiguration _configuration = configuration;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public async Task<AuthResponse> LoginAsync(string username, string password) {
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
        if (result.Succeeded) {
            var user = await _userManager.FindByNameAsync(username);
            AuthResponse reponse = new() {
                Token    = GenerateJwtToken(user),
                ClientId = user.ClientId.GetValueOrDefault(),
                IsAdmin  = user.IsAdmin
            };

            return reponse;
        }

        throw new Exception("Error en el inicio de sesión.");
    }

    public async Task<AuthResponse> RegisterAsync(string username, string password, Client client, bool isAdmin = false) {
        IdentityResult result;
        ApplicationUser user = new() {
            UserName = username,
            IsAdmin  = isAdmin
        };

        if (!isAdmin) {
            var register = await _clientRepository.Create(client);
            user.ClientId = register.Id;
        }

        result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded) {
            await _signInManager.SignInAsync(user, isPersistent: false);
            AuthResponse reponse = new() {
                Token    = GenerateJwtToken(user),
                ClientId = user.ClientId.GetValueOrDefault(),
                IsAdmin  = false
            };

            return reponse;
        }

        throw new Exception("El registo no se pudo completar.");
    }

    private string GenerateJwtToken(ApplicationUser user) {
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("ClientId", user.ClientId.ToString()),
            new Claim("IsAdmin", user.IsAdmin.ToString())
        };

        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
