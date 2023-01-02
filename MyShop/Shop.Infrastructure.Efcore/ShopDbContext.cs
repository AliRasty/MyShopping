using Microsoft.EntityFrameworkCore;
using Shop.Domin.ProductAgg;
using Shop.Domin.ProductCategoryAgg;
using Shop.Infrastructure.Efcore.Mapping;

namespace Shop.Infrastructure.Efcore
{
    public class ShopDbContext : DbContext
    {
        

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}