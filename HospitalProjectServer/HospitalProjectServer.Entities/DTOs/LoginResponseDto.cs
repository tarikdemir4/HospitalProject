using HospitalProjectServer.Entities.Enums;

namespace HospitalProjectServer.Entities.DTOs;
public sealed record LoginResponseDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
