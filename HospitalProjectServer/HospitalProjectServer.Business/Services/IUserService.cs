using HospitalProjectServer.Entities.DTOs;
using TS.Result;

namespace HospitalProjectServer.Business.Services;
public interface IUserService
{
    
    Task<Result<string>>CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken);
}
