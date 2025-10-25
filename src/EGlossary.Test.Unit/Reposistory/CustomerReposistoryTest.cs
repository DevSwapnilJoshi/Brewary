using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Persistence;
using EGlossary.Persistence.Reposistory;
using EGlossary.Service.Mapping;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EGlossary.UnitTest.Reposistory
{
    public class CustomerReposistoryTest
    {
        private readonly DbContextOptionsBuilder<InMemoryDbContext> dbContext;
        private readonly InMemoryDbContext _imDbContext;
        private readonly CustomerReposistory _customerReposistory;
        public IMapper _moqMapper;

        public CustomerReposistoryTest()
        {
            dbContext = new DbContextOptionsBuilder<InMemoryDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _imDbContext = new InMemoryDbContext(dbContext.Options);
            _moqMapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
            _customerReposistory = new CustomerReposistory(_imDbContext, _moqMapper);
        }

        [Fact]
        public async Task CreateCustomer_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _customerReposistory.CreateCustomer(new CustomerEntity());
            response.Should().NotBe(null);
            response.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task GetAll_Customer_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _customerReposistory.GetCustomers();
            response.Should().NotBeEmpty();
            response.Count().Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Get_Customer_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _customerReposistory.GetCustomerById(1);
            response.Id.Should().Be(1);
        }

        [Fact]
        public async Task Delete_Customer_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _customerReposistory.DeleteCustomer(1);
            response.Should().BeTrue();
        }
    }
}