using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_Cart.Models
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        
    }
}
