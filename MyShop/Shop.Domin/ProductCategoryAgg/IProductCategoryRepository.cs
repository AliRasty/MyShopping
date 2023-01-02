using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BaseFramework.Domin;
using Shop.Application.Contract.ProductCategory;

namespace Shop.Domin.ProductCategoryAgg
{
    public interface IProductCategoryRepository :IRepository<long,ProductCategory>
    {

        List<ProductCategoryViewModel> GetCategory();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);
    }
}