using AutoFixture;
using EGlossary.Service.Models;
using EGlossary.Service.Validator;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace EGlossary.UnitTest.Validator
{
    public class ProductValidatorTest
    {
        private readonly ProductValidator _validator;
        private Fixture _fixture;

        public ProductValidatorTest()
        {
            _validator = new ProductValidator();
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "WHEN ProductName not given Then result should be Error Message")]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var command = _fixture.Create<ProductDto>();
            command.ProductName = string.Empty;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.ProductName);
        }

        [Fact(DisplayName = "WHEN ProductName given Then result should be Null Or No error message")]
        public void Should_Have_No_Error_When_Name_Provide()
        {
            var command = _fixture.Create<ProductDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }

        [Fact(DisplayName = "WHEN category Zero Then result should be Error Message")]
        public void Should_Have_Error_When_Category_Is_Zero()
        {
            var command = _fixture.Create<ProductDto>();
            command.CategoryId = null;
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CategoryId);
        }

        [Fact(DisplayName = "WHEN categoryId supplied Then result should be null Or No error message")]
        public void Should_Have_Error_When_Category_Is_Not_Zero()
        {
            var command = _fixture.Create<ProductDto>();
            var result = _validator.TestValidate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}