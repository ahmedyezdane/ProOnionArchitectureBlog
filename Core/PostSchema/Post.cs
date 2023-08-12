using Core.UserSchema;

namespace Core.PostSchema;

public class Post
{
    public int PostId { get; set; }

    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public string PictureName { get; set; }
    public string Slug { get; set; }
    public bool IsDeleted { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
