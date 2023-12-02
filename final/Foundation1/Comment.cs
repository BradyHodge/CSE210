public class Comment
{
    private string commenterName;
    private string commentText;

    public Comment(string commenterName, string commentText)
    {
        this.commenterName = commenterName;
        this.commentText = commentText;
    }

    public string CommenterName
    {
        get { return commenterName; }
        set { commenterName = value; }
    }

    public string CommentText
    {
        get { return commentText; }
        set { commentText = value; }
    }
}
