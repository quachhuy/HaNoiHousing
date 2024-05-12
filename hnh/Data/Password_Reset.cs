using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hnh.Data
{
    public class Password_Reset
    {
        // create table password_resets with id, email, token, created_at.
        public int password_resetid { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public DateTime? createdat { get; set; }
        public int userid { get; set; }
        public User? User { get; set; }

    }
}
