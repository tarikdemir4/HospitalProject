using AutoMapper;
using HospitalProjectServer.Business.Services;
using HospitalProjectServer.Entities.DTOs;
using HospitalProjectServer.Entities.Enums;
using HospitalProjectServer.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace HospitalProjectServer.DataAccess.Services;
internal sealed class UserService(
    UserManager<User> userManager,
    IMapper mapper) : IUserService
{
    public async Task<Result<string>> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken)
    {

        if (request.Email is not null)
        {
            bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email);
            if (isEmailExists)
            {
                return Result<string>.Failure(StatusCodes.Status409Conflict, "Email already has token");
            }
        }

        if (request.UserName is not null)
        {
            bool isUserNameExists = await userManager.Users.AnyAsync(p => p.UserName == request.UserName);
            if (isUserNameExists)
            {
                return Result<string>.Failure(StatusCodes.Status409Conflict, "UserName already has token");
            }
        }

        if (request.IdentityNumber != "11111111111")
        {
            bool isIdentityNumberExists = await userManager.Users.AnyAsync(p => p.IdentityNumber == request.IdentityNumber);
            if (isIdentityNumberExists)
            {
                return Result<string>.Failure(StatusCodes.Status409Conflict, "IdentityNumber already exists");
            }
        }

        User user = mapper.Map<User>(request);

        Random random = new();
        user.EmailConfirmCode = random.Next(100000, 999999);
        user.EmailConfirmCodeSendDate = DateTime.UtcNow;


        if (request.Specialty is not null)
        {
            user.DoctorDetail = new DoctorDetail()
            {
                Specialty = (Specialty)request.Specialty,
                WorkingDays = request.WorkingDays ?? new()
            };
        }

        IdentityResult result;

        if (request.Password is not null)
        {
            result = await userManager.CreateAsync(user, request.Password);
        }
        else
        {
            result = await userManager.CreateAsync(user);
        }

        if (result.Succeeded)
        {
            return Result<string>.Succeed("User Create is successfull");
            //Onay maili gönderme işlemi
        }

        return Result<string>.Failure(500, result.Errors.Select(s => s.Description).ToList());
    }
}
