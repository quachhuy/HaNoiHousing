using hnh.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hnh.Data
{
    public class Property
    {
        // create table properties with id, title, description, price, area, address,count_view, latlng, image, user_id, district_id, category_id, district_id,utilities, phone, approve, slug.
        public int propertyid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double area { get; set; }
        public string address { get; set; }
        public int countview { get; set; }
        public string latLng { get; set; }
        public string image { get; set; }
        //--------------------
        public int userid { get; set; }
        public User? User { get; set; }
        //--------------------
        public int districtid { get; set; }
        public District? district { get; set; }
        //--------------------
        public int categoryid { get; set; }
        public Category? category { get; set; }
        //--------------------
        public string furniture { get; set; } 
        public string phone { get; set; }
        public bool approve { get; set; } // 0: chua duyet, 1: da duyet
        public string slug { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Report>? Reports { get; set; }
    }
}
