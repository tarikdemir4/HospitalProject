using HospitalProjectServer.Entities.DTOs;
using TS.Result;

namespace HospitalProjectServer.Business.Services;

public interface IAuthService
{
    Task<Result<LoginResponseDto>> LoginAsync(LoginRequestDto request,CancellationToken cancellationToken);
}
