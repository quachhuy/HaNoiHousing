using hnh.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hnh.Data
{
    public class Report
    {
        // create table reports with id, user_id, room_id, content, created_at, updated_at.
        public int reportid { get; set; }
        public string content { get; set; }
        public DateTime? createdat { get; set; }

        public int userid { get; set; }
        public User? User { get; set; }

        public int propertyid { get; set; }
        public Property? Property { get; set; }

        public int reportstatusid { get; set; }
        public Report_Status? Report_Status { get; set; }

    }
}
