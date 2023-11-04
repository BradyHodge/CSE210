using System;
using System.Threading;

public abstract class Activity
{
    public string ActivityName { get; private set; }
    public string ActivityDescription { get; private set; }
    public int Duration { get; private set; }

    protected Activity(string name, string description)
    {
        ActivityName = name;
        ActivityDescription = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Activity: {ActivityName}");
        Console.WriteLine($"Description: {ActivityDescription}");
        Console.WriteLine("Please set the duration of the activity in seconds.");
        Duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        // Simulate a pause with a countdown
        Countdown(Duration);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("You have done a good job!");
        Thread.Sleep(2000); // Pause for effect
        Console.WriteLine($"Activity completed: {ActivityName} for {Duration} seconds.");
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i} seconds...");
            Thread.Sleep(1000);
        }
        Console.Write("\r "); // Clear the line
    }

    // Abstract method to be implemented by derived classes
    public abstract void StartActivity();
}
