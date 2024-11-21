using HospitalProjectServer.Business.Services;
using HospitalProjectServer.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProjectServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateUserDto request, CancellationToken cancellationToken)
    {
        var response = await userService.CreateUserAsync(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}
