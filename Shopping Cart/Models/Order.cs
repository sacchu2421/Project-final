using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
      
    }
}
