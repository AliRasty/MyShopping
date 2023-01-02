using System.Collections.Generic;
using _0_Framework.Application;
using BaseFramework.Application;
using Shop.Application.Contract.Product;
using Shop.Domin.ProductAgg;

namespace Shop.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMassages.DuplicationRecord);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();

            var entity = _productRepository.Get(command.Id);


            if (entity == null)
                return operation.Failed(ApplicationMassages.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name &&
                                               x.Id != command.Id))
            {
                return operation.Failed(ApplicationMassages.DuplicationRecord);
            }
            var slug = command.Slug.Slugify();

            entity.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug,
                command.Keywords, command.MetaDescription, command.CategoryId);


            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult IsStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
            {
                return operation.Failed(ApplicationMassages.RecordNotFound);
            }
            product.InStock();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult IsNotStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product==null)
            {
                return operation.Failed(ApplicationMassages.RecordNotFound);
            }
            product.NotInStok();
            _productRepository.SaveChanges();   
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}