using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Company;
using Test.Application.Queries.Base;

namespace Test.Application.DTOs.Employee
{
    public class EmployeesDTO : Collection<EmployeeDTO>, IQueryDataResponse
    {
        public EmployeesDTO(IList<EmployeeDTO> employees) : base(employees) { }
    }
}
