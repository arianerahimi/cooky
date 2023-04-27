using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testweb.Models;

namespace testweb.ViewModel
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string englishname { get; set; }
        public string title { get; set; }
        
        public IFormFile imgbytes { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public List<ProductImageViewModel> ProductsImagesViews { get; set; }
    }
}
