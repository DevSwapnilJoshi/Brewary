using AutoMapper;
using EGlossary.Service.Features.CustomerFeatures.Commands;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using Xunit;
using static EGlossary.Service.Features.CustomerFeatures.Commands.DeleteCustomerCommandHandler;

namespace EGlossary.UnitTest.Services.CustomerService.Commands
{
    public class DeleteCustomerCommandTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        public Mock<IMapper> _moqMapper;

        public DeleteCustomerCommandTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _moqMapper = new Mock<IMapper>();
        }

        [Fact]
        public void DeleteCustomerTest_With_ValidRequest()
        {
            var moqDbContext = _dbContextTest.MoqCustomerReposistory;
            moqDbContext.Setup(x => x.DeleteCustomer(1));
            var deleteCustomerCommandHandler = new DeleteCustomerCommandHandler()
            {
                Id = 1
            };
            var customerQueryHandler = new DeleteCustomerByIdCommandHandler(moqDbContext.Object, _moqMapper.Object);
            var customer = customerQueryHandler.Handle(deleteCustomerCommandHandler, default);
            customer.Id.Should().Be(customer.Id);
            moqDbContext.Verify(v => v.DeleteCustomer(1));
        }
    }
}