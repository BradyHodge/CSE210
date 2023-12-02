using System;
using System.Collections.Generic;

public class Video
{
    // Member variables
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
    }
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public int LengthInSeconds
    {
        get { return lengthInSeconds; }
        set { lengthInSeconds = value; }
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
