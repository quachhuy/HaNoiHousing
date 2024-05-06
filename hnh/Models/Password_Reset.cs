namespace hnh.Models
{
    public class Password_Reset
    {
        public int PasswordResetId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
