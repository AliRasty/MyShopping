using System.Collections.Generic;
using System.Linq;
using BaseFramework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contract.Product;
using Shop.Domin.ProductAgg;

namespace Shop.Infrastructure.Efcore.Repository
{
    public class ProductRepository :RepositoryBase<long,Product> ,IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x=>new EditProduct
            {
                Id=x.Id,
                Name = x.Name,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                CategoryId = x.CategoryId

            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.
                Include(x=>x.Category)
                .Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                Category = x.Category.Name,
                Picture = x.Picture,
                Categoryid = x.CategoryId,
                CreationDate = x.CreateDate.ToString()
            });


            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name == searchModel.Name);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                query = query.Where(x => x.Code == searchModel.Code);
            }

            if (searchModel.CategoryId !=0)
            {
                query = query.Where(x => x.Categoryid ==searchModel.CategoryId);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
    
}