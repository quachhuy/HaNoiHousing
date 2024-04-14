using System.ComponentModel.DataAnnotations;

namespace hnh.server.Data
{
    public class Report
    {
        // create table reports with id, user_id, room_id, content, created_at, updated_at.
        public int ReportId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
