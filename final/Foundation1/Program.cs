using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Learn Programming", "CodeAcademy", 300);
        Video video2 = new Video("Understanding OOP Concepts", "TechTutorials", 600);

        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This really helped, thanks!"));

        video2.AddComment(new Comment("Charlie", "Very insightful."));
        video2.AddComment(new Comment("Dave", "I appreciate the detailed examples."));

        var videos = new Video[] { video1, video2 };

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine();
        }
    }
}
