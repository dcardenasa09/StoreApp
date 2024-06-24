using Store.Entities.DTOs;
using Store.Entities.Entities;
using Store.Entities.Common.Models;

namespace Store.Business.Services.Auth;

public interface IAuthService {
    Task<AuthResponse> LoginAsync(string username, string password);
    Task<AuthResponse> RegisterAsync(string username, string password, Client client, bool isAdmin = false);
}