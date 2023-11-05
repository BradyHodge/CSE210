using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> listingPrompts;
    private Random random = new Random();

    public ListingActivity(string name, string description, List<string> prompts) : base(name, description)
    {
        listingPrompts = prompts;
    }

    public override void StartActivity()
    {
        DisplayStartingMessage();

        // Select a random prompt
        string selectedPrompt = listingPrompts[random.Next(listingPrompts.Count)];
        Console.WriteLine(selectedPrompt);

        var items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        Console.WriteLine("List as many items as you can think of in the Activity Duration. ");
        Countdown(10);

        while (DateTime.Now < endTime)
        {
            Console.Write(" >  ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"You have listed {items.Count} items.");

        DisplayEndingMessage();
    }
}
