using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hnh.Data
{
    [Table("password_resets")]
    public class password_reset
    {
        // create table password_resets with id, email, token, created_at.
        [Key]
        public int password_resetId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
