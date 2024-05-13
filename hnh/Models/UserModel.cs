namespace hnh.Models
{
    public class UserModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }

        public Guid remembertoken { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public string status { get; set; }

    }
}
