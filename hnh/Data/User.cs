using hnh.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace hnh.Data
{
    public class User
    {
        //create table users with id, name, email, password, right not null default = 0, phone, avatar,remember_token, created_at, updated_at, status.
        public int userid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; } // 0: user, 1: admin

        public string phone { get; set; }
        public string avatar { get; set; }

        public Guid remembertoken { get; set; }
        public DateTime? createdat { get; set; }

        public DateTime? updatedat { get; set; }
        public string status { get; set; } // 1: active, 0: deactive

        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Password_Reset> Password_Resets { get; set; }

    }
}
