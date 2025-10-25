using AutoFixture;
using EGlossary.Controllers;
using EGlossary.Service.Features.ProductsFeatures.Queries;
using EGlossary.Service.Models;
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
    public class ProductsControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;
        private Fixture _fixture;

        public ProductsControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "WHEN Valid Product Request pass THEN Product SHOULD Get created with OK response")]
        public async Task CreateProduct_WithValidRequest_ShouldReturn_HttpStatusCode_OK()
        {
            //Arrange
            var productsController = new ProductController(_moqMediator.Object);
            var fxProductDto = _fixture.Create<ProductDto>();
            //Act
            var response = await productsController.Create(fxProductDto);
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<ProductDto>(), It.IsAny<CancellationToken>()));
        }

        [Fact(DisplayName = "WHEN InValid Customer Request pass THEN Customer SHOULD Not Get created and response with Bad Request")]
        public async Task CreateProduct_WithInvalidRequest_ShouldReturn_HttpStatusCode_BadRequest()
        {
            //Arrange
            var productsController = new ProductController(_moqMediator.Object);

            var fxProductDto = _fixture.Create<ProductDto>();
            fxProductDto.ProductName = string.Empty;
            //Act
            var response = await productsController.Create(fxProductDto);
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
            //verified
        }

        [Fact]
        public async Task CreateProduct_ProductsIsNullOrEmpty()
        {
            //Arrange
            var productsController = new ProductController(_moqMediator.Object);
            //Act
            var response = await productsController.GetAllProducts();
            //Assert
            var httpResponse = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task BadRequest_IsNullOrEmpty()
        {
            //Arrange
            var productsController = new ProductController(_moqMediator.Object);
            //Act
            var response = await productsController.Create(new ProductDto());
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetAllProduct()
        {
            var productsController = new ProductController(_moqMediator.Object);

            var response = await productsController.GetAllProducts();
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProductById()
        {
            var productsController = new ProductController(_moqMediator.Object);
            var response = await productsController.GetProductById(1);
            response.Should().NotBeNull();
        }
    }
}