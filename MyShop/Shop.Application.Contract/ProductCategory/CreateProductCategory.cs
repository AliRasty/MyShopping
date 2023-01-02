using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Shop.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Display(Name = "نام")]

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        public string Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        [Display(Name = "کلمات کلیدی")]

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Keyword { get; set; }
        [Display(Name = "توضیحات متا")]

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MetaDescription { get; set; }
        [Display(Name = "اسلاک")]

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Slug { get; set; }
    }
}