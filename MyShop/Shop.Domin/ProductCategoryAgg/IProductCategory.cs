using System.Collections.Generic;

namespace Shop.Domin.ProductCategoryAgg
{
    public interface IProductCategory
    {
        void Create(ProductCategory command);
        ProductCategory GetById(long id);
        List<ProductCategory> GetAll();
    }
}