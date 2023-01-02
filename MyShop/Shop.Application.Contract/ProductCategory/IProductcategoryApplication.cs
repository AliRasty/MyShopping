using BaseFramework.Application;
using System.Collections.Generic;

namespace Shop.Application.Contract.ProductCategory
{
    public interface IProductcategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        List<ProductCategoryViewModel> GetCategory();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);

        EditProductCategory GetDetails(long Id);


    }
}