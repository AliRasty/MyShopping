using Microsoft.EntityFrameworkCore;
using Shop.Domin.ProductCategoryAgg;
using Shop.Infrastructure.Efcore.Mapping;

namespace Shop.Infrastructure.Efcore
{
    public class ShopDbContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}