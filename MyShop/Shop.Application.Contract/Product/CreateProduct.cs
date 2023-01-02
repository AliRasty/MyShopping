using Shop.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string Code { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public double UnitPrice { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string Slug { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string Keywords { get; set; }
       
        public string MetaDescription { get;  set; }
        public long CategoryId { get; set; }

        public List<ProductCategoryViewModel> Categories { get; set; }

    }
}
