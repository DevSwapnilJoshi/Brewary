using AutoFixture;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.CategoryFeatures.Queries;
using EGlossary.UnitTest.DbContext;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static EGlossary.Service.Features.CategoryFeatures.Queries.GetAllCategoriesQuery;

namespace EGlossary.UnitTest.Services.CategoryService.Queries
{
    public class GetCategoryQueriesTest : IClassFixture<DbContextTest>
    {
        private readonly DbContextTest _dbContextTest;
        private readonly GetAllCategoriesQuery _getAllCategoriesQuery;

        public GetCategoryQueriesTest(DbContextTest dbContextTest)
        {
            _dbContextTest = dbContextTest;
            _getAllCategoriesQuery = _dbContextTest.Fixture.Create<GetAllCategoriesQuery>();
        }

        [Fact]
        public void GetAllCategoryQueryHandler_Should_Return_CategoryList_IfOrdersExists()
        {
            var moqDbContext = _dbContextTest.MoqCategoryReposistory;
            moqDbContext.Setup(x => x.GetCategories()).ReturnsAsync(_dbContextTest.Fixture.Create<IEnumerable<CategoryEntity>>);
            var categoryQueryHandler = new GetAllCategoryQueryHandler(moqDbContext.Object);
            var categoryList = categoryQueryHandler?.Handle(_getAllCategoriesQuery, default);
            categoryList!.Result.Count().Should().BeGreaterThanOrEqualTo(1);
            moqDbContext.Verify(v => v.GetCategories());
        }

        [Fact]
        public void GetAllCategoryQueryHandler_Return_Null_IfCategorytListIsEmpty()
        {
            var moqDbContext = _dbContextTest.MoqCategoryReposistory;
            moqDbContext.Setup(x => x.GetCategories()).ReturnsAsync(Enumerable.Empty<CategoryEntity>());
            var categoryQueryHandler = new GetAllCategoryQueryHandler(moqDbContext.Object);
            var categoryList = categoryQueryHandler?.Handle(_getAllCategoriesQuery, default);
            categoryList!.Result.Should().BeNull();
            moqDbContext.Verify(v => v.GetCategories());
        }

        [Fact]
        public void GetAllCategoryQueryHandler_Should_HandleNullException()
        {
            var categoryQueryHandler = new GetAllCategoryQueryHandler(null);
            Action act = () => categoryQueryHandler?.Handle(null, default);
            act.Should().NotThrow();
        }
    }
}