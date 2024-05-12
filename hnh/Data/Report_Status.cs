using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hnh.Data
{
    public class Report_Status
    {
        public int reportstatusid { get; set; }
        public string statusname { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
