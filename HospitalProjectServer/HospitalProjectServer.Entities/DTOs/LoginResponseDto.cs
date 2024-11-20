﻿using HospitalProjectServer.Entities.Enums;

namespace HospitalProjectServer.Entities.DTOs;
public sealed class LoginResponseDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
