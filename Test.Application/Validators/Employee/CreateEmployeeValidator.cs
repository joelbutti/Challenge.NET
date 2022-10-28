using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Commands.Company;
using Test.Application.Commands.Employee;
using Test.Application.Queries.Company;
using Test.Application.Validators.Base;
using Test.Repository;

namespace Test.Application.Validators.Employee
{
    public class CreateEmployeeValidator : IBusinessValidationHandler<CreateEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Validate(CreateEmployeeCommand request)
        {
            return await _unitOfWork.CompanyRepository.CompanyExistsByGuidAsync(request.CompanyId)
                ? ValidationResult.Fail(new FieldError(nameof(request.CompanyId), "Already exists"))
                : ValidationResult.Success;
        }
    }
}
