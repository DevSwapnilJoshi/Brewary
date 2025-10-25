using EGlossary.Persistence.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EGlossary.Persistence
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
        }

        public DbSet<ProductDataModel> Product { get; set; }
        public DbSet<CustomerDataModel> Customer { get; set; }
        public DbSet<CategoryDataModel> Category { get; set; }
        public DbSet<OrderDataModel> Order { get; set; }

        public DbSet<BreweryDataModel> Brewery { get; set; }
    }
}