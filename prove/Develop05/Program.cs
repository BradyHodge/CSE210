using System;
using System.Collections.Generic;

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int userScore = 0;

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordGoalAchievement();
                    break;
                case "3":
                    ViewGoals();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("1. Create Goal");
        Console.WriteLine("2. Record Goal Achievement");
        Console.WriteLine("3. View Goals");
        Console.WriteLine("4. Display Score");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }

private static void CreateGoal()
{
    Console.WriteLine("Enter goal name:");
    string name = Console.ReadLine();
    Console.WriteLine("Enter point value for the goal:");
    int pointValue = int.Parse(Console.ReadLine());
    Console.WriteLine("Select goal type (1. Simple, 2. Eternal, 3. Checklist):");
    string type = Console.ReadLine();

    switch (type)
    {
        case "1":
            goals.Add(new SimpleGoal(name, pointValue));
            break;
        case "2":
            goals.Add(new EternalGoal(name, pointValue));
            break;
        case "3":
            Console.WriteLine("Enter completion target for the checklist goal:");
            int target = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, pointValue, target));
            break;
        default:
            Console.WriteLine("Invalid goal type.");
            break;
    }
    Console.WriteLine("Goal created successfully.");
}
private static void RecordGoalAchievement()
{
    Console.WriteLine("Enter the name of the goal to record:");
    string goalName = Console.ReadLine();
    var goal = goals.Find(g => g.Name.Equals(goalName));
    if (goal != null)
    {
        if (goal is EternalGoal eternalGoal)
        {
            eternalGoal.RecordOccurrence();
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            checklistGoal.RecordCompletion();
        }
        else
        {
            goal.MarkAsComplete();
        }
        Console.WriteLine("Goal achievement recorded.");
    }
    else
    {
        Console.WriteLine("Goal not found.");
    }
}
private static void ViewGoals()
{
    foreach (var goal in goals)
    {
        Console.WriteLine($"{goal.Name} - Completed: {goal.IsCompleted} - Score: {goal.CalculateScore()}");
    }
}
private static void DisplayScore()
{
    userScore = goals.Sum(g => g.CalculateScore());
    Console.WriteLine($"Your total score is: {userScore}");
}

}
