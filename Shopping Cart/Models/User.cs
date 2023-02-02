using System.ComponentModel.DataAnnotations;

namespace Shopping_Cart.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Address { get; set; }

        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
