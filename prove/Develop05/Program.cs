using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int userScore = 0;

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            DisplayScore();
            Console.WriteLine();
            DisplayMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ViewGoals();
                    break;
                case "3":
                    ExportGoalsToCSV();
                    break;
                case "4":
                    ImportGoalsFromCSV();
                    break;
                case "5":
                    RecordGoalAchievement();
                    break;
                case "6":
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
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals to CSV");
        Console.WriteLine("4. Load Goals from CSV");
        Console.WriteLine("5. Record Goal Achievement");
        Console.WriteLine("6. Quit");
        Console.Write("Select an option: ");
    }

private static void CreateGoal()
{
    Console.Write("Select goal type (1. Simple, 2. Eternal, 3. Checklist):");
    string type = Console.ReadLine();
    Console.Write("Enter goal name:");
    string name = Console.ReadLine();
    Console.Write("Enter a short description for the goal:");
    string description = Console.ReadLine();
    Console.Write("Enter point value for the goal:");
    int pointValue = int.Parse(Console.ReadLine());
    

    switch (type)
    {
        case "1":
            goals.Add(new SimpleGoal(name, pointValue, description));
            break;
        case "2":
            goals.Add(new EternalGoal(name, pointValue, description));
            break;
        case "3":
            Console.WriteLine("Enter completion target for the checklist goal:");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bonus points for the checklist goal:");
            int bonusPoints = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, pointValue, target, bonusPoints, description));
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
    int goalNumber = 1;
    foreach (var goal in goals)
    {
        if (goal is EternalGoal eternalGoal)
        {
            Console.WriteLine($"{goalNumber}. [ ]{goal.Name} - Goal Count: {eternalGoal.Occurrences}");
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            if (goal.IsCompleted)
                Console.WriteLine($"{goalNumber}. [X]{goal.Name} - Completion Count: {checklistGoal.CompletionCount}/{checklistGoal.CompletionTarget}");
            else
                Console.WriteLine($"{goalNumber}. [ ]{goal.Name} - Completion Count: {checklistGoal.CompletionCount}/{checklistGoal.CompletionTarget}");
        }
        else
        {
            if (goal.IsCompleted)
                Console.WriteLine($"{goalNumber}. [X]{goal.Name}");
            else
                Console.WriteLine($"{goalNumber}. [ ]{goal.Name}");
        }
        goalNumber++;
    }
}
private static void DisplayScore()
{
    userScore = goals.Sum(g => g.CalculateScore());
    Console.WriteLine($"Your total score is: {userScore}");
}
private static void ExportGoalsToCSV()
{
    StringBuilder csvContent = new StringBuilder();
    csvContent.AppendLine("Goal Name,Description,Point Value,Is Completed,Score,Goal Type,Completion Count,Completion Target,Bonus Points");

    foreach (var goal in goals)
    {
        string line = $"\"{goal.Name}\",\"{goal.Description}\",{goal.PointValue},{goal.IsCompleted},{goal.CalculateScore()}";
        string goalType;
        string additionalData = "";

        if (goal is SimpleGoal)
        {
            goalType = "SimpleGoal";
            additionalData = ",,,";
        }
        else if (goal is EternalGoal eternalGoal)
        {
            goalType = "EternalGoal";
            additionalData = $",{eternalGoal.Occurrences},,";
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            goalType = "ChecklistGoal";
            additionalData = $",{checklistGoal.CompletionCount},{checklistGoal.CompletionTarget},{checklistGoal.BonusPoints}";
        }
        else
        {
            goalType = "Unknown";
        }

        line += $",{goalType}{additionalData}";
        csvContent.AppendLine(line);
    }

    Console.WriteLine("Enter the file path to save the CSV:");
    string filePath = Console.ReadLine();
    File.WriteAllText(filePath, csvContent.ToString());
    Console.WriteLine("Goals exported to CSV file successfully.");
}




private static void ImportGoalsFromCSV()
{
    Console.WriteLine("Enter the file path to import the CSV:");
    string filePath = Console.ReadLine();

    if (!File.Exists(filePath))
    {
        Console.WriteLine("File not found.");
        return;
    }

    var lines = File.ReadAllLines(filePath);
    foreach (string line in lines.Skip(1))
    {
        var data = line.Split(',');

        if (data.Length < 9) 
        {
            Console.WriteLine("Invalid data format in CSV.");
            continue;
        }

        string name = data[0].Trim('\"');
        string description = data[1].Trim('\"'); 
        int pointValue = int.Parse(data[2]);
        bool isCompleted = bool.Parse(data[3]);
        string goalType = data[5];

        Goal goal;
        switch (goalType)
        {
            case "SimpleGoal":
                goal = new SimpleGoal(name, pointValue, description);
                break;
            case "EternalGoal":
                int occurrences = int.Parse(data[6]);
                var eternalGoal = new EternalGoal(name, pointValue, description);
                for (int i = 0; i < occurrences; i++)
                {
                    eternalGoal.RecordOccurrence();
                }
                goal = eternalGoal;
                break;
            case "ChecklistGoal":
                int completionCount = int.Parse(data[6]);
                int completionTarget = int.Parse(data[7]);
                int bonusPoints = int.Parse(data[8]);
                var checklistGoal = new ChecklistGoal(name, pointValue, completionTarget, bonusPoints, description);
                for (int i = 0; i < completionCount; i++)
                {
                    checklistGoal.RecordCompletion();
                }
                goal = checklistGoal;
                break;
            default:
                Console.WriteLine($"Invalid goal type: {goalType}");
                continue;
        }

        if (isCompleted && goal is not EternalGoal)
        {
            goal.MarkAsComplete();
        }
        goals.Add(goal);
    }

    Console.WriteLine("Goals imported from CSV file successfully.");
}

}



