using hnh.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hnh.Data
{
    [Table("comments")]
    public class Comment
    {
        // create table comments with id, content,user_id,room_id.
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string? Content { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property?  Property { get; set; }

    }
}
