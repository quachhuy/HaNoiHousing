using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hnh.server.Data
{
    public class Property
    {
        // create table properties with id, title, description, price, area, address,count_view, latlng, image, user_id, district_id, category_id, district_id,utilities, phone, approve, slug.
        public int PropertyId { get; set; }
        [Required]

        public string? Title { get; set; }
        [Required]

        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Area { get; set; }
        [Required]

        public string? Address { get; set; }
        [Required]

        public int CountView { get; set; }
        [Required]

        public string? LatLng { get; set; }
        [Required]

        public string? Image { get; set; }
        [Required]

        public int UserId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? Utilities { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        [DefaultValue(0)]
        public bool Approve { get; set; }
        [Required]
        public string? Slug { get; set; }
    }
}
