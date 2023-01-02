using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Shop.Application;
using Shop.Application.Contract.Product;
using Shop.Application.Contract.ProductCategory;

namespace BookShopHost.Areas.Administrator.Pages.Shoping.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> productViewModels;
        public ProductSearchModel searchViewModels;
        public SelectList productCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductcategoryApplication _productCategoryApplication;



        public IndexModel(IProductApplication productApplication,IProductcategoryApplication productcategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication= productcategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            productCategories = new SelectList(
                _productCategoryApplication.GetCategory(),
                "Id",
                "Name");


            productViewModels = _productApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            var product = new CreateProduct { 
            
            Categories = _productCategoryApplication.GetCategory()
            
            };
            return Partial("./Create", new CreateProduct());
        }

        public JsonResult OnPostCreate(CreateProduct create)
        {
            var productCreates = _productApplication.Create(create);
            return new JsonResult(productCreates);
        }


        public IActionResult OnGetEdit(long id)
        {
            var proEdit= _productApplication.GetDetails(id);
            proEdit.Categories = _productCategoryApplication.GetCategory();

            return Partial("./Edit", proEdit);
        }


        public JsonResult OnPostEdit(EditProduct edit)
        {
            var editProduct = _productApplication.Edit(edit);
            return new JsonResult(editProduct);
        }
    }
}
