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

        int BreathIn = 3;
        int BreathOut = 4;

            try {
                Console.Write("How many seconds would you like to breathe in each time? ");
            BreathIn = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Defaulting to 3 seconds.");
            }

            try {
                Console.Write("How many seconds would you like to breathe out each time? ");
            BreathOut = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Defaulting to 4 seconds.");
            }


        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            Countdown(BreathIn);
            Console.WriteLine();
            Console.Write("Breathe out...");
            Countdown(BreathOut);
            
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}
