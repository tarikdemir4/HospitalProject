using HospitalProjectServer.Business.Services;
using HospitalProjectServer.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace HospitalProjectServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto request, CancellationToken cancellationToken)
    {
        var response = await authService.LoginAsync(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}
