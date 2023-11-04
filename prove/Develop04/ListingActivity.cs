using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> listingPrompts;

    public ListingActivity(string name, string description, List<string> prompts) : base(name, description)
    {
        listingPrompts = prompts;
    }

    public override void StartActivity()
    {
        DisplayStartingMessage();

        foreach (var prompt in listingPrompts)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("Start listing items. Type 'done' to finish.");
            var items = new List<string>();
            string input;
            do
            {
                input = Console.ReadLine();
                if (input.ToLower() != "done" && !string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                }
            } while (input.ToLower() != "done");

            Console.WriteLine($"You have listed {items.Count} items.");
            Thread.Sleep(2000); // Pause for effect
        }

        DisplayEndingMessage();
    }
}
