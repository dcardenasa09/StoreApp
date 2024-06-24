using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class AuthResponse {

    public string? Token { get; set; }
    public int ClientId { get; set; }
    public bool IsAdmin { get; set; }
}