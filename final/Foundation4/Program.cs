using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    
        List<Activity> activities = new List<Activity>();

    
        Running run = new Running(new DateTime(2023, 11, 24), 30, 3.0);
        Cycling cycle = new Cycling(new DateTime(2023, 11, 24), 45, 15.0);
        Swimming swim = new Swimming(new DateTime(2023, 11, 24), 60, 20);

    
        activities.Add(run);
        activities.Add(cycle);
        activities.Add(swim);

    
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
