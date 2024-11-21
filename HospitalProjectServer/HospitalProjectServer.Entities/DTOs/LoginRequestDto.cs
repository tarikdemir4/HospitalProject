using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectServer.Entities.DTOs;
public sealed record LoginRequestDto(
    string EmailOrUserName,
    string Password,
    bool RememberMe=false);
