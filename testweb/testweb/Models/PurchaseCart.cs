using System.ComponentModel.DataAnnotations.Schema;
using testweb.Areas.Identity.Data;

namespace testweb.Models
{
    public class purchaseCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public DateTime createdDate { get; set; }

        public List<PurchaseCartItem> PurchaseCartItems { get; set; }

        public bool isOpen { get; set; }
    }
}
