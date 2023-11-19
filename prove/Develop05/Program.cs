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
                    ExportGoalsToCSV();
                    break;
                case "6":
                    ImportGoalsFromCSV();
                    break;
                case "7":
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
        Console.WriteLine("5. Export Goals to CSV");
        Console.WriteLine("6. Import Goals from CSV");
        Console.WriteLine("7. Exit");
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
private static void ExportGoalsToCSV()
    {
        StringBuilder csvContent = new StringBuilder();
        csvContent.AppendLine("Goal Name,Point Value,Is Completed,Score");
        foreach (var goal in goals)
        {
            string line = $"\"{goal.Name}\",{goal.PointValue},{goal.IsCompleted},{goal.CalculateScore()}";
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
        foreach (string line in lines.Skip(1)) // Skipping the header line
        {
            var data = line.Split(',');

            if (data.Length != 4)
            {
                Console.WriteLine("Invalid data format in CSV.");
                continue;
            }

            string name = data[0].Trim('\"');
            int pointValue = int.Parse(data[1]);
            bool isCompleted = bool.Parse(data[2]);
            // Assuming the CSV only contains SimpleGoals for simplicity
            SimpleGoal goal = new SimpleGoal(name, pointValue);
            if (isCompleted)
            {
                goal.MarkAsComplete();
            }
            goals.Add(goal);
        }

        Console.WriteLine("Goals imported from CSV file successfully.");
    }
}



