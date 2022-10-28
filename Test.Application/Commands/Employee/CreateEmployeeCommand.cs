using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Commands.Base;
using Test.Domain.Entities;

namespace Test.Application.Commands.Employee;
public record CreateEmployeeCommand(string FullName, string IdNumber, DateTime DateOfBirth, Guid CompanyId) 
    : BaseCommand, IRequest<CreateEmployeeResponse>;
