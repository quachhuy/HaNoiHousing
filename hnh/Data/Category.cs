using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hnh.Data
{
    [Table("categories")]
    public class Category
    {
        // create table categories with id, name, slug.
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}
