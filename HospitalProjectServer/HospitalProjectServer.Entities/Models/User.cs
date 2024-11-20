﻿using HospitalProjectServer.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectServer.Entities.Models;
public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public string FullAdress { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateOnly? DateOfBirth { get; set; }
    public string? BloodType { get; set; }
    public UserType UserType { get; set; } = UserType.User;
    public Guid? DoctorDetailId { get; set; }
    public DoctorDetail? DoctorDetail { get; set; }
}
