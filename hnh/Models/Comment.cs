﻿namespace hnh.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PropertyId { get; set; }
    }
}
