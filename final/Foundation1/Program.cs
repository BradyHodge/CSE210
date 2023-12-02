using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Exploring the Cosmos", "AstroVlogs", 1200);
        Video video2 = new Video("The Art of Cooking", "ChefJulia", 900);
        Video video3 = new Video("Mystery of the Ocean Depths", "SeaExplorer", 1500);
        Video video4 = new Video("Journey Through the History", "HistoricFacts", 1800);

        video1.AddComment(new Comment("Alex", "Absolutely fascinating!"));
        video1.AddComment(new Comment("Taylor", "Can't wait for the next episode."));
        video1.AddComment(new Comment("Jordan", "This is amazing!"));

        video2.AddComment(new Comment("Morgan", "Delicious recipes."));
        video2.AddComment(new Comment("Chris", "Your cooking tips are the best!"));
        video2.AddComment(new Comment("Pat", "Love your presentation style!"));

        video3.AddComment(new Comment("Casey", "So intriguing!"));
        video3.AddComment(new Comment("Riley", "Learned so much about marine life."));
        video3.AddComment(new Comment("Sam", "Great exploration video!"));

        video4.AddComment(new Comment("Jamie", "History brought to life."));
        video4.AddComment(new Comment("Drew", "Very informative and engaging."));
        video4.AddComment(new Comment("Robin", "Your storytelling is fantastic!"));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine();
        }
    }
}
