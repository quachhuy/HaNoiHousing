using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hnh.Data
{
    public class District
    {
        // create table districts with id, name, slug, city_id.
        public int districtid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
