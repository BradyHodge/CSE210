using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    public override void StartActivity()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(4000); // Simulate breathing in for 4 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(4000); // Simulate breathing out for 4 seconds
        }

        DisplayEndingMessage();
    }
}
