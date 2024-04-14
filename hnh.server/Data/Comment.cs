namespace hnh.server.Data
{
    public class Comment
    {
        // create table comments with id, content,user_id,room_id.
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int PropertyId { get; set; }
    }
}
