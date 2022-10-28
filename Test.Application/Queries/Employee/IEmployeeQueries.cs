using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;

namespace Test.Application.Queries.Employee
{
    public interface IEmployeeQueries : IQueriesCollection
    {
        Task<QueryResponse<EmployeeDTO>> GetEmployeeByIdAsync(Guid employeeId,
    CancellationToken cancellationToken = default);

        Task<QueryPaginatedResponseDTO<EmployeesDTO>> ListEmployees(
            CancellationToken cancellationToken = default);
    }
}
