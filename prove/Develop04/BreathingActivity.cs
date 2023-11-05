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
            Console.WriteLine();
            Console.Write("Breathe in...");
            Countdown(4);
            Console.WriteLine();
            Console.Write("Breathe out...");
            Countdown(5);
            
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}
