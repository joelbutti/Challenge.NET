using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Commands.Base;
using Test.Application.Queries.Base;

namespace Test.Application.DTOs.Employee
{
    public class EmployeeDTO : ICommandDataResponse, IQueryDataResponse
    {
        public string IdNumber { get;  set; }
        public string FullName { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public Guid CompanyId { get;  set; }
    }
}
