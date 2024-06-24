using System.Threading.Tasks;
using Store.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Business.Services.Auth;
using Store.Entities.Common.Models;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase {

    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var result = await _authService.LoginAsync(model.Username, model.Password);
        if (result != null) {
            return Ok(result);
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model) {
        if (ModelState.IsValid) {
            var client = new Client {
                Name     = model.FirstName,
                LastName = model.LastName,
                Address  = model.Address,
                Email    = model.Username,
                Phone    = model.Phone
            };

            var result = await _authService.RegisterAsync(model.Username ?? "", model.Password ?? "", client);
            if (result != null) {
                return Ok(result);
            }

            return BadRequest("Registration failed");
        }
        return BadRequest("Invalid model");
    }
}
