using System.ComponentModel.DataAnnotations;

namespace hnh.server.Data
{
    public class District
    {
        // create table districts with id, name, slug, city_id.
        public int DistrictId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Slug { get; set; }
    }
}
