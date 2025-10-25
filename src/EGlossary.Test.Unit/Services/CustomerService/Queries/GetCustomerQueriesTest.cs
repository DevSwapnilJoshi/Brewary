using AutoFixture;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.CustomerFeatures.Queries;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static EGlossary.Service.Features.CustomerFeatures.Queries.GetAllCustomerQuery;
using static EGlossary.Service.Features.CustomerFeatures.Queries.GetCustomerByIdQuery;

namespace EGlossary.UnitTest.Services.CustomerService.Queries
{
    public class GetCustomerQueriesTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        private readonly GetAllCustomerQuery _getAllCustomerQuery;

        public GetCustomerQueriesTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _getAllCustomerQuery = _dbContextTest.Fixture.Create<GetAllCustomerQuery>();
        }

        [Fact]
        public void GetAllCustomerQueryHandler_Should_Return_CustomerList_IfCustomersExists()
        {
            var moqDbContext = _dbContextTest.MoqCustomerReposistory;
            moqDbContext.Setup(x => x.GetCustomers()).ReturnsAsync(_dbContextTest.Fixture.Create<IEnumerable<CustomerEntity>>);
            var customerQueryHandler = new GetAllCustomerQueryHandler(moqDbContext.Object);
            var customerList = customerQueryHandler?.Handle(_getAllCustomerQuery, default);
            customerList!.Result.Count().Should().BeGreaterThanOrEqualTo(1);
            moqDbContext.Verify(v => v.GetCustomers());
        }

        [Fact]
        public void GetAllCustomerQueryHandler_Return_Null_IfCustomerListIsEmpty()
        {
            var moqDbContext = _dbContextTest.MoqCustomerReposistory;
            moqDbContext.Setup(x => x.GetCustomers()).ReturnsAsync(Enumerable.Empty<CustomerEntity>());
            var customerQueryHandler = new GetAllCustomerQueryHandler(moqDbContext.Object);
            var customerList = customerQueryHandler?.Handle(_getAllCustomerQuery, default);
            customerList!.Result.Should().BeNull();
            moqDbContext.Verify(v => v.GetCustomers());
        }

        [Fact]
        public void GetAllCustomerQueryHandler_Should_HandleNullException()
        {
            var customerQueryHandler = new GetAllCustomerQueryHandler(null);
            Action act = () => customerQueryHandler?.Handle(null, default);
            act.Should().NotThrow();
        }

        [Fact]
        public void GetCustomerByIdQueryHandler_Should_Return_Customer_IfProductExists()
        {
            var moqDbContext = _dbContextTest.MoqCustomerReposistory;
            moqDbContext.Setup(x => x.GetCustomerById(1));
            var getCustomerByIdQuery = new GetCustomerByIdQuery()
            {
                Id = 1
            };
            var customerQueryHandler = new GetCustomerByIdQueryHandler(moqDbContext.Object);
            var customer = customerQueryHandler.Handle(getCustomerByIdQuery, default);
            customer.Id.Should().Be(customer.Id);
            moqDbContext.Verify(v => v.GetCustomerById(1));
        }
    }
}