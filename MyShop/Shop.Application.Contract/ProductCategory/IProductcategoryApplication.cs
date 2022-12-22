using System.Collections.Generic;

namespace Shop.Application.Contract.ProductCategory
{
    public interface IProductcategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);

        List<Domin.ProductCategoryAgg.ProductCategory> Search(ProductCategorySearchModel command);

        Domin.ProductCategoryAgg.ProductCategory GetDetails(long Id);
    }
}