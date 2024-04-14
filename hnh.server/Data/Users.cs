using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace hnh.server.Data
{
    public class Users
    {
        //create table users with id, name, email, password, right not null default = 0, phone, avatar,remember_token, created_at, updated_at, status.
        public int UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [DefaultValue(0)]
        public int Right { get; set; }
        [Required]

        public string? Phone { get; set; }
        [DefaultValue("no-avatar.jpg")]
        public string? Avatar { get; set; }
        
        public string? RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
            
        public DateTime? UpdatedAt { get; set; }
        [Required]
        [DefaultValue("1")]
        public string? Status { get; set; }
    }
}
