using AutoFixture;
using EGlossary.Controllers;
using EGlossary.Service.Features.CustomerFeatures.Commands;
using EGlossary.Service.Features.CustomerFeatures.Queries;
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
    public class CustomerControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;
        private Fixture _fixture;

        public CustomerControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "WHEN Valid Customer Request pass THEN Customer SHOULD Get created with OK response")]
        public async Task CreateCustomer_WithValidRequest_ShouldReturn_HttpStatusCode_OK()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            var fxCustomerDto = _fixture.Create<CustomerDto>();

            //Act
            var response = await customerController.Create(fxCustomerDto);
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<CustomerDto>(), It.IsAny<CancellationToken>()));
        }

        [Fact(DisplayName = "WHEN InValid Customer Request pass THEN Customer SHOULD Not Get created and response with Bad Request")]
        public async Task CreateCustomer_WithInvalidRequest_ShouldReturn_HttpStatusCode_BadRequest()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            var fxCustomerDto = _fixture.Create<CustomerDto>();
            fxCustomerDto.CustomerName = string.Empty;

            //Act
            var response = await customerController.Create(fxCustomerDto);
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [Fact(DisplayName = "WHEN request pass Then Cutomer list will recevied in response")]
        public async Task GetAll_CustomerIsNotNullOrEmpty()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            //Act
            var response = await customerController.GetAll();
            //Assert
            var httpResponse = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<GetAllCustomerQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetCustomer_IsSuccessful()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            //Act
            var response = await customerController.GetCustomerById(1);
            //Assert
            var httpResponse = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<GetCustomerByIdQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task DeleteCustomer_IsSuccessful()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            var response = await customerController.DeleteCustomer(1);
            //Assert
            var httpResponse = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<DeleteCustomerCommandHandler>(), It.IsAny<CancellationToken>()));
        }
    }
}