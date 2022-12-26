using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Shop.Application.Contract.ProductCategory;

namespace Shop.Domin.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory command);
        ProductCategory GetById(long id);
        List<ProductCategory> GetAll();
        bool Exists(Expression<Func<ProductCategory,bool>> expression);

        void SaveChanges();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);
    }
}