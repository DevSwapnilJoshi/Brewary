using AutoFixture;
using EGlossary.Service.Models;
using EGlossary.Service.Validator;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace EGlossary.UnitTest.Validator
{
    public class OrderValidatorTest
    {
        private readonly OrderValidator _validator;
        private Fixture _fixture;

        public OrderValidatorTest()
        {
            _validator = new OrderValidator();
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "WHEN VoucherNumber not given Then result should be Error Message")]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = _fixture.Create<OrderDto>();
            command.VoucherNumber = string.Empty;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.VoucherNumber);
        }

        [Fact(DisplayName = "WHEN VoucherNumber given Then result should be Null Or No error message")]
        public void Should_Have_No_Error_When_Name_Provide()
        {
            var command = _fixture.Create<OrderDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }

        [Fact(DisplayName = "WHEN CustomerId is  Provide 0 Then result should be Error Message")]
        public void Should_Have_Error_When_CustomerIdIsNull()
        {
            var command = _fixture.Create<OrderDto>();
            command.CustomerId = null;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CustomerId);
        }

        [Fact(DisplayName = "WHEN CustomerId  is supplied greater then 0 Then result should be null Or No error message")]
        public void Should_Have_Error_When__AddressIs_Not_Null()
        {
            var command = _fixture.Create<OrderDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }

        [Fact(DisplayName = "WHEN Phone is not Provide Then result should be Error Message")]
        public void Should_Have_Error_When_Phone_Is_Null()
        {
            var command = _fixture.Create<OrderDto>();
            command.Product = null;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Product);
        }

        [Fact(DisplayName = "WHEN valid Phone Request is supplied Then result should be null Or No error message")]
        public void Should_Have_Error_When_Phone_Is_Not_Null()
        {
            var command = _fixture.Create<OrderDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}