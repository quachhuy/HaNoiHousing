using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hnh.Data
{
    public class Category
    {
        // create table categories with id, name, slug.
        public int categoryid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
