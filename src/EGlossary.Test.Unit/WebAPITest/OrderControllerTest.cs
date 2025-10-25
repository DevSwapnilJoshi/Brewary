using EGlossary.Controllers;
using EGlossary.Service.Features.OrderFeatures.Commands;
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
    public class OrdersControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;

        public OrdersControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task CreateOrderTest()
        {
            //Arrange
            var orderController = new OrderController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<OrderDto>(), It.IsAny<CancellationToken>()));
            //Act
            var response = await orderController.Create(new OrderDto());
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<OrderDto>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task CreateOrder_BadRequest_WhenNull()
        {
            //Arrange
            var orderController = new OrderController(_moqMediator.Object);
            //Act
            var response = await orderController.Create(new OrderDto());
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<OrderDto>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task BadRequest_IsNullOrEmpty()
        {
            //Arrange
            var orderController = new OrderController(_moqMediator.Object);
            //Act
            var response = await orderController.Create(new OrderDto());
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.Created);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<OrderDto>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task GetAllOrder()
        {
            var orderController = new OrderController(_moqMediator.Object);
            var response = await orderController.GetAll();
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOrderById()
        {
            var orderController = new OrderController(_moqMediator.Object);
            var response = await orderController.GetById(1);
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateOrderTest()
        {
            //Arrange
            var orderController = new OrderController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<OrderDto>(), It.IsAny<CancellationToken>()));
            //Act
            var response = await orderController.Update(1, new OrderDto());
            //Assert
            var httpResponse = Assert.IsType<ObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<OrderDto>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task DeleteOrder_IsSuccessful()
        {
            //Arrange
            var orderController = new OrderController(_moqMediator.Object);
            var response = await orderController.Delete(1);
            //Assert
            var httpResponse = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
            //verified
            _moqMediator.Verify(x => x.Send(It.IsAny<DeleteOrderCommandHandler>(), It.IsAny<CancellationToken>()));
        }
    }
}