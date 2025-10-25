using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.CustomerFeatures.Commands;
using EGlossary.Service.Models;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using Xunit;

namespace EGlossary.UnitTest.Services.CustomerService.Commands
{
    public class CreateCustomerCommandTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        public Mock<IMapper> _moqMapper;

        public CreateCustomerCommandTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _moqMapper = new Mock<IMapper>();
        }

        [Fact]
        public void CreateCustomerTest_With_ValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqCustomerReposistory;
            moqDbContext.Setup(x => x.CreateCustomer(It.IsAny<CustomerEntity>())).ReturnsAsync(1);
            var createCustomerCommandHandler = new CreateCustomerCommandHandler(moqDbContext.Object, _moqMapper.Object);
            var response = createCustomerCommandHandler.Handle(new CustomerDto(), default);
            response.Should().NotBeNull();
            response.Result.Should().Be(1);
            moqDbContext.Setup(s => s.CreateCustomer(It.IsAny<CustomerEntity>()));
        }

        [Fact]
        public void CreateCustomerTest_With_ValidInValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqCustomerReposistory;
            moqDbContext.Setup(x => x.CreateCustomer(It.IsAny<CustomerEntity>())).ReturnsAsync(0);
            var createCustomerCommandHandler = new CreateCustomerCommandHandler(moqDbContext.Object, _moqMapper.Object);
            var response = createCustomerCommandHandler.Handle(new CustomerDto(), default);
            response.Should().NotBeNull();
            response.Result.Should().Be(0);
            moqDbContext.Setup(s => s.CreateCustomer(It.IsAny<CustomerEntity>()));
        }
    }
}