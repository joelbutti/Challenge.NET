using FluentValidation;
using Test.Application.Commands.Company;
using Test.Application.Commands.Employee;

namespace Test.API.Validators
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(c => c.IdNumber)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(c => c.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Fecha de cumpleaños debe ser menor a hoy.")
                .NotEmpty();

            RuleFor(c => c.CompanyId)
                .NotEmpty();
        }
    }
}
