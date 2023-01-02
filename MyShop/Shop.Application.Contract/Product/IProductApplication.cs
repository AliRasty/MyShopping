using System.Collections.Generic;
using BaseFramework.Application;
using BaseFramework.Domin;

namespace Shop.Application.Contract.Product
{
    public interface IProductApplication 
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);

        OperationResult IsStock(long id);
        OperationResult IsNotStock(long id);


        EditProduct GetDetails(long id);

        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}