using System.ComponentModel.DataAnnotations.Schema;

namespace testweb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string englishname { get; set; }
        public int price { get; set; }
        public int conunt { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        //public List<ProductImage> productImages { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
      
        
        public string? descreption { get; set; }

 

        //public int productCategoryId { get; set; }
        //[ForeignKey("productCategoryId")]

        //public ProductCategory ProductCategory { get; set; }

        public List<PurchaseCartItem> PurchaseCartItems { get; set; }

    }
}
