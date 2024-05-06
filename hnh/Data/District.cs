using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hnh.Data
{
    [Table("Districts")]
    public class District
    {
        // create table districts with id, name, slug, city_id.
        [Key]
        public int DistrictId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Slug { get; set; }
    }
}
