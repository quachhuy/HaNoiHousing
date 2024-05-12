using hnh.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hnh.Data
{
    public class Comment
    {
        public int commentid { get; set; }
        public string content { get; set; }
        public string? createdat { get; set; }
        
        public int? userid { get; set; }
        public User User { get; set; }


        public int propertyid { get; set; }
        public Property Property { get; set; }

    }
}
