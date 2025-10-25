using AutoFixture;
using EGlossary.Service.Models;
using EGlossary.Service.Validator;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace EGlossary.UnitTest.Validator
{
    public class CustomerValidatorTest
    {
        private readonly CustomerValidator _validator;
        private Fixture _fixture;

        public CustomerValidatorTest()
        {
            _validator = new CustomerValidator();
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "WHEN CustomerName not given Then result should be Error Message")]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = _fixture.Create<CustomerDto>();
            command.CustomerName = string.Empty;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CustomerName);
        }

        [Fact(DisplayName = "WHEN CustomerName given Then result should be Null Or No error message")]
        public void Should_Have_No_Error_When_Name_Provide()
        {
            var command = _fixture.Create<CustomerDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }

        [Fact(DisplayName = "WHEN Address is not Provide Then result should be Error Message")]
        public void Should_Have_Error_When_AddressIsNull()
        {
            var command = _fixture.Create<CustomerDto>();
            command.Address = string.Empty;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Address);
        }

        [Fact(DisplayName = "WHEN valid Address Request is supplied Then result should be null Or No error message")]
        public void Should_Have_Error_When__AddressIs_Not_Null()
        {
            var command = _fixture.Create<CustomerDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }

        [Fact(DisplayName = "WHEN Phone is not Provide Then result should be Error Message")]
        public void Should_Have_Error_When_Phone_Is_Null()
        {
            var command = _fixture.Create<CustomerDto>();
            command.Phone = string.Empty;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Phone);
        }

        [Fact(DisplayName = "WHEN valid Phone Request is supplied Then result should be null Or No error message")]
        public void Should_Have_Error_When_Phone_Is_Not_Null()
        {
            var command = _fixture.Create<CustomerDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}