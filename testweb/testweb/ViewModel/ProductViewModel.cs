
using System.ComponentModel.DataAnnotations;
using testweb.Models;

namespace testweb.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "نام کالا وارد نمایید")]

        public string name { get; set; }
        [Required(ErrorMessage = "نام کالا وارد نمایید")]
        public string englishname { get; set; }
        //[Required(ErrorMessage = "قیمت کالا وارد نمایید")]

        //public List<IFormFile> images { get; set; }
        [Required(ErrorMessage = "قیمت کالا وارد نمایید")]
        public int price { get; set; }
        [Required(ErrorMessage = "تعداد کالا وارد نمایید")]
        public int count { get; set; }
        
        public byte[] imgbyts { get; set; }
        [Required(ErrorMessage = "توضیحات کالا وارد نمایید")]
        public string descreption { get; set; }
        //public List<IFormFile> images { get; set; }
        [Required(ErrorMessage = "برند کالا وارد نمایید")]
        public int BrandId { get; set; }
        public List<ProductImageViewModel> ProductsImagesViews { get; set; }

        //public string brandname { get; set; }

        //public int productCategoryId { get; set; }
    }
}
