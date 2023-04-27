namespace testweb.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
