using Core.UserSchema;

namespace Core.PostSchema;

public class Comment
{
    public int CommentId { get; set; }
    public string Text { get; set; }
    public DateTime SubmitionDate { get; set; }
    public bool IsDeleted { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }
}
