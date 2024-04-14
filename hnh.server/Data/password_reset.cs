using System.ComponentModel.DataAnnotations;

namespace hnh.server.Data
{
    public class password_reset
    {
        // create table password_resets with id, email, token, created_at.
        
        public int password_resetId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}
