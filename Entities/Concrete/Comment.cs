using System;

namespace Entities.Concrete
{
   public class Comment
    {
        public int CommentId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
    }
}
