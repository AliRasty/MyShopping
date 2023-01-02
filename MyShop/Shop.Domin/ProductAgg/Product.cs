using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BaseFramework.Domin;
using Shop.Domin.ProductCategoryAgg;

namespace Shop.Domin.ProductAgg
{
    public class Product :EntetyBase
    {
        public string Name { get;private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public bool IsInStock { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; set; }

        public Product(string name, string code, double unitPrice,
            string shortDescription, string description, 
            string picture, string pictureAlt, string pictureTitle, string slug,
            string keywords, string metaDescription ,long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            IsInStock = true;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
           
        }

        public void Edit(string name, string code, double unitPrice,
            string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, string slug,
            string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            IsInStock = false;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            CategoryId = categoryId;
            MetaDescription = metaDescription;

        }

        public void InStock()
        {
            IsInStock=true;
        }

        public void NotInStok()
        {
            IsInStock=false;
        }
    }
}
