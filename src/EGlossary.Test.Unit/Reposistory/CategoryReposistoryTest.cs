using AutoMapper;
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
    public class CategoryReposistoryTest
    {
        private readonly DbContextOptionsBuilder<InMemoryDbContext> dbContext;
        private readonly InMemoryDbContext _imDbContext;
        private readonly CategoryReposistory _categoryReposistory;
        public IMapper _moqMapper;

        public CategoryReposistoryTest()
        {
            dbContext = new DbContextOptionsBuilder<InMemoryDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _imDbContext = new InMemoryDbContext(dbContext.Options);

            _moqMapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
            _categoryReposistory = new CategoryReposistory(_imDbContext, _moqMapper);
        }

        [Fact]
        public async Task GetAll_Categories_Response_Should_NotBeNullOrEmpty()
        {
            var response = await _categoryReposistory.GetCategories();
            response.Should().NotBeEmpty();
            response.Count().Should().BeGreaterThanOrEqualTo(1);
        }
    }
}