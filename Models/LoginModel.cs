using System.ComponentModel.DataAnnotations;

namespace inventoryApiRest.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }
        
        [Required]
        [StringLength(255)]
        public required string Password { get; set; }
    }
}
