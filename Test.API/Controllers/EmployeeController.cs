using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.API.DTOs.Errors;
using Test.Application.Commands.Company;
using Test.Application.Commands.Employee;
using Test.Application.DTOs.Company;
using Test.Application.DTOs.Employee;
using Test.Application.Queries.Base;
using Test.Application.Queries.Company;
using Test.Application.Queries.Employee;

namespace Test.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEmployeeQueries _employeeQueries;

        public EmployeeController(IMediator mediator, IEmployeeQueries employeeQueries)
        {
            _mediator = mediator;
            _employeeQueries = employeeQueries;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(PaginatedDataResponse<EmployeesDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundDTO), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<QueryPaginatedResponseDTO<EmployeesDTO>>> List(CancellationToken cancellationToken)
        {
            return await _employeeQueries.ListEmployees(cancellationToken);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundDTO), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<QueryResponse<EmployeeDTO>>> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _employeeQueries.GetEmployeeByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreateEmployeeResponse>> Create(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send<CreateEmployeeResponse>(command, cancellationToken));
        }
    }
}
