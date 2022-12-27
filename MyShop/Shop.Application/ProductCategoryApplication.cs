using Shop.Application.Contract.ProductCategory;
using Shop.Domin.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using _0_Framework.Application;
using BaseFramework.Application;

namespace Shop.Application
{
    public class ProductCategoryApplication : IProductcategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }


        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name  == command.Name))
                return operation.Failed("قبلا رکوردی با این نام ثبت شده است لطفا مجدد تلاش کنید");


            var slug = GenerateSlug.Slugify(command.Slug);
            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture,
                                                      command.PictureAlt, command.PictureTitle, 
                                                      command.Keyword
                                                      ,command.MetaDescription, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);

            if (_productCategoryRepository.Exists(x=>x.Name == command.Name
                                                     && x.Id == command.Id))
            {
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            }

            var slug = GenerateSlug.Slugify(command.Slug);
            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle,
                command.Keyword
                , command.MetaDescription, slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long Id)
        {
            return _productCategoryRepository.GetDetails(Id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            return _productCategoryRepository.Search(command);
        }
    }
}
