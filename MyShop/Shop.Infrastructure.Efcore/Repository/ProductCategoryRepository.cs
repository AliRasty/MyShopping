using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BaseFramework.Infrastructure;
using Shop.Application.Contract.ProductCategory;
using Shop.Domin.ProductCategoryAgg;

namespace Shop.Infrastructure.Efcore.Repository
{
    public class ProductCategoryRepository :RepositoryBase<long,ProductCategory> , IProductCategoryRepository
    {
        private readonly ShopDbContext _context;

        public ProductCategoryRepository(ShopDbContext context) : base(context) 
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug

                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = DateTime.Now.ToString()
            });
            if (!string.IsNullOrWhiteSpace(command.Name))
                query = query.Where(x => x.Name.Contains(command.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}