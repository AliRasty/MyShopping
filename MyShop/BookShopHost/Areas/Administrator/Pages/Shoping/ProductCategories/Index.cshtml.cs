using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Contract.ProductCategory;
using Shop.Application;
using System.Collections.Generic;

namespace BookShopHost.Areas.Administrator.Pages.Shoping.ProductCategories
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategoryViewModels;
        public ProductCategorySearchModel SearchModel;
        private readonly IProductcategoryApplication _application;
      
        public IndexModel(IProductcategoryApplication application)
        {
            _application = application;
        }



        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategoryViewModels =
                _application.Search(searchModel);
        }
    }
}
