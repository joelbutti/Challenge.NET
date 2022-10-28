using AutoMapper;
using Test.Application.DTOs.Employee;

namespace Test.Application.DTOs.Company;

public class CompanyAutoMapper: Profile
{
    public CompanyAutoMapper()
    {
        CreateMap<Domain.Entities.Company, CompanyDTO>();
        CreateMap<Domain.Entities.Employee, EmployeeDTO>();
    }
}