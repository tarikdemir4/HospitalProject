using AutoMapper;
using HospitalProjectServer.Entities.DTOs;
using HospitalProjectServer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectServer.DataAccess.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
