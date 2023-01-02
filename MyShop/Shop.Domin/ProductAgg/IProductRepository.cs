using System.Collections.Generic;
using BaseFramework.Domin;
using Shop.Application.Contract.Product;

namespace Shop.Domin.ProductAgg
{
    public interface IProductRepository: IRepository<long,Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}