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
        Console.Clear();
        Console.WriteLine($"Welcome to the {ActivityName} activity.");
        Console.WriteLine(ActivityDescription);
        Console.WriteLine("Please set the duration of the activity in seconds.");
        Duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        SpinningAnimation(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good Job!");
        SpinningAnimation(3);
        Console.WriteLine($"Activity completed: {ActivityName} for {Duration} seconds.");
        SpinningAnimation(3);
        Console.Clear();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        
    }
    public void SpinningAnimation(int durationInSeconds)
{
    var spinner = new[] { '|', '/', '-', '\\' };
    int counter = 0;
    DateTime end = DateTime.Now.AddSeconds(durationInSeconds);

    while (DateTime.Now < end)
    {
        Console.Write($"\b \b{spinner[counter++ % spinner.Length]}");
        Thread.Sleep(100);
    }
    Console.Write("\b \b"); 
}


    // Abstract method to be implemented by derived classes
    public abstract void StartActivity();
}
