using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Commands.Company;
using Test.Application.DTOs.Company;
using Test.Application.DTOs.Employee;
using Test.Repository;

namespace Test.Application.Commands.Employee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEmployeeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employee = Domain.Entities.Employee.New(request.IdNumber, request.FullName, request.DateOfBirth, request.CompanyId);

            _logger.LogInformation("----- Creating Employee - FullName: {@FullName} - IdNumber: {@IdNumber} - DateOfBirth: {@DateOfBirth} - CompanyId: {@CompanyId}"
                , request.IdNumber, request.FullName, request.DateOfBirth, request.CompanyId);

            employee = await _unitOfWork.EmployeeRepository.CreateAsync(employee, cancellationToken);
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);

            return new CreateEmployeeResponse
            {
                Result = _mapper.Map<EmployeeDTO>(employee)
            };
        }
    }
}
