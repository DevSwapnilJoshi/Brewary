using EGlossary.Controllers;
using EGlossary.Service.Features.CategoryFeatures.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EGlossary.UnitTest.WebAPITest
{
    public class CategoryControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;

        public CategoryControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task GetAll_CategoriesIsNotNullOrEmpty()
        {
            //Arrange
            var categoryController = new CategoryController(_moqMediator.Object);
            //Act
            var response = await categoryController.GetAllCategory();
            //Assert
            var httpResponse = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<GetAllCategoriesQuery>(), It.IsAny<CancellationToken>()));
        }
    }
}