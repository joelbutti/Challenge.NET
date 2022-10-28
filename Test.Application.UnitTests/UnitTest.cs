using MediatR;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Test.API.Controllers;
using Test.Application.Commands.Company;
using Test.Application.Queries.Company;
using Test.Application.Validators.Company;
using Test.Repository;
using Xunit;

namespace Test.Application.UnitTests;

public class UnitTest
{
    [Fact]
    public async Task CreateCompanyValidatorSucceededWhenCompanyDoesNotExist()
    {
        //Test CreateCompanyValidator
        //Arrange
        Mock<IUnitOfWork> unitOfWork = new();

        CreateCompanyValidator _sut = new(unitOfWork.Object);
        unitOfWork.Setup(x => x.CompanyRepository
                        .CompanyExistsAsync(It.IsAny<string>()))
                        .ReturnsAsync(false);
        //Act
        var validationResult = await _sut.Validate(new CreateCompanyCommand("test", "124578"));

        //Assert
        Assert.True(validationResult.IsSuccessful);
    }
    
    [Fact]
    public async Task CreateCompanyValidatorMustFailWhenCompanyExist()
    {
        //Test CreateCompanyValidator
        //Arrange
        Mock<IUnitOfWork> unitOfWork = new();

        CreateCompanyValidator _sut = new (unitOfWork.Object);
        unitOfWork.Setup(x => x.CompanyRepository
                        .CompanyExistsAsync(It.IsAny<string>()))
                        .ReturnsAsync(true);

        //Act
        var validationResult = await _sut.Validate(new CreateCompanyCommand("test", "12347"));

        //Assert
        Assert.False(validationResult.IsSuccessful);
    }
}