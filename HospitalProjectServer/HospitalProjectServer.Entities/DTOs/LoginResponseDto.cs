using HospitalProjectServer.Entities.Enums;

namespace HospitalProjectServer.Entities.DTOs;
public sealed class LoginResponseDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires,
    Guid UserId,
    string? Email,
    string FullName,
    string? UserName,
    UserType UserType);
