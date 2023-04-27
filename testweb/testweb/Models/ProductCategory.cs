using System.ComponentModel.DataAnnotations.Schema;

namespace testweb.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string categoryName { get; set; }

        //public List<Product> Products { get; set; }
    }
}
