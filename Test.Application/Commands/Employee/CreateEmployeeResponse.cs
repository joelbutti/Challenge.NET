using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Commands.Base;
using Test.Application.DTOs.Company;
using Test.Application.DTOs.Employee;

namespace Test.Application.Commands.Employee;
public record CreateEmployeeResponse : CommandResponse<EmployeeDTO>;
