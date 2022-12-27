using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application;
using Shop.Application.Contract.ProductCategory;
using Shop.Domin.ProductCategoryAgg;
using Shop.Infrastructure.Efcore;
using Shop.Infrastructure.Efcore.Repository;

namespace Shop.Configurtion
{
    public class ManagementConfiguration
    {
        public static void Configure(IServiceCollection services ,string connectionString)
        {
            services.AddTransient<IProductcategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
