using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Company;
using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;
using Test.Application.Queries.Company;

namespace Test.Application.Queries.Employee
{
    public class EmployeeQueries : QueryRunner, IEmployeeQueries
    {

        public EmployeeQueries(QueryConnectionString connectionString, ILogger<EmployeeQueries> logger) :
        base(connectionString, logger)
        { }

        public async Task<QueryResponse<EmployeeDTO>> GetEmployeeByIdAsync(Guid employeeId, CancellationToken cancellationToken = default)
        {
            var employee = await RunQueryFirstAsync(
                @"SELECT id_number, full_name, date_of_birth, company_id
                     FROM employee
                    WHERE id = @id",
                new
            {
                id = employeeId
                }, cancellationToken);

            if (employee == null)
                return QueryResponse<EmployeeDTO>.NotFound();

            return QueryResponse<EmployeeDTO>.Success(
                MapToEmployeeDTO(employee));
        }

        public async Task<QueryPaginatedResponseDTO<EmployeesDTO>> ListEmployees(CancellationToken cancellationToken = default)
        {
            var employees = await RunQueryAsync(
                @"SELECT id_number, full_name, date_of_birth, company_id
                FROM employee", cancellationToken);

            return new QueryPaginatedResponseDTO<EmployeesDTO>(
                new EmployeesDTO(employees.AsList().Select<dynamic, EmployeeDTO>(c => MapToEmployeeDTO(c))
                    .ToList<EmployeeDTO>()),10, 1, 1);
        }

        private static EmployeeDTO MapToEmployeeDTO(dynamic row)
        {
            return new EmployeeDTO()
            {
                IdNumber = row.id_number,
                FullName = row.full_name,
                DateOfBirth = row.date_of_birth,
                CompanyId = row.company_id
            };
        }
    }
}
