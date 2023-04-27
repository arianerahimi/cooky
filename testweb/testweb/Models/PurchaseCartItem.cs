using System.ComponentModel.DataAnnotations.Schema;

namespace testweb.Models
{
    public class PurchaseCartItem
    {
        public int Id { get; set; }

        public int PurchaseCartId { get; set; }
        [ForeignKey("PurchaseCartId")]
        public purchaseCart PurchaseCart { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int count { get; set; }
    }
}
