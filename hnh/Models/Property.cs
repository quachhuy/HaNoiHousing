using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace hnh.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double Area { get; set; }
        public string? Address { get; set; }
        public int CountView { get; set; }
        public string? LatLng { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }
        public int DistrictId { get; set; }
        public int CategoryId { get; set; }
        public string? Utilities { get; set; }
        public string? Phone { get; set; }
        public bool Approve { get; set; }
        public string? Slug { get; set; }
    }
}
