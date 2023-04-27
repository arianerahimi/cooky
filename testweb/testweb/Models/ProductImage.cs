using System.ComponentModel.DataAnnotations.Schema;

namespace testweb.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string title { get; set; }
        public byte[] img { get; set; }


        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
