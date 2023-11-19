// Show creativity and exceed the core requirements:
// Added auto-save feature


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int userScore = 0;

    public static void Main(string[] args)
    {
        bool running = true;
        bool AutoSave = false;
        string autoSaveFilePath = "Goals.csv";
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
                    if (AutoSave)
                    {
                        ExportGoalsToCSV(autoSaveFilePath);
                    }
                    break;
                case "2":
                    ViewGoals();
                    break;
                case "3":
                    Console.WriteLine("Enter the file path to save the CSV:");
                    string filePath = Console.ReadLine();
                    ExportGoalsToCSV(filePath);
                    
                    break;
                case "4":
                    ImportGoalsFromCSV();
                    break;
                case "5":
                    RecordGoalAchievement();
                    if (AutoSave)
                    {
                        ExportGoalsToCSV(autoSaveFilePath);
                    }
                    break;
                case "6":
                    AutoSave = !AutoSave;
                    Console.WriteLine($"Auto-Save is now {(AutoSave ? "enabled" : "disabled")}.");
                    if (AutoSave)
                    {
                        Console.WriteLine("Enter the file name to save the CSV:");
                        autoSaveFilePath = Console.ReadLine();
                    }
                    break;
                case "7":
                    running = false;
                    if (AutoSave)
                    {
                        ExportGoalsToCSV(autoSaveFilePath);
                        Console.WriteLine("Save updated.");
                    }
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
        Console.WriteLine("6. Toggle Auto-Save");
        Console.WriteLine("7. Quit");
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
    if (goals.Count == 0)
    {
        Console.WriteLine("No goals available.");
        return;
    }

    Console.WriteLine("Select a goal to record achievement:");
    for (int i = 0; i < goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {goals[i].Name} - {goals[i].Description}");
    }
    Console.Write("Enter goal number:");

    if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
    {
        Console.WriteLine("Invalid selection.");
        return;
    }

    var goal = goals[goalNumber - 1];

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
    Console.WriteLine($"Achievement recorded for goal: {goal.Name}");
}

private static void ViewGoals()
{
    int goalNumber = 1;
    foreach (var goal in goals)
    {
        if (goal is EternalGoal eternalGoal)
        {
            Console.WriteLine($"{goalNumber}. [ ]{goal.Name} ({goal.Description}) - Goal Count: {eternalGoal.Occurrences}");
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            if (goal.IsCompleted)
                Console.WriteLine($"{goalNumber}. [X]{goal.Name} ({goal.Description}) - Completion Count: {checklistGoal.CompletionCount}/{checklistGoal.CompletionTarget}");
            else
                Console.WriteLine($"{goalNumber}. [ ]{goal.Name} ({goal.Description}) - Completion Count: {checklistGoal.CompletionCount}/{checklistGoal.CompletionTarget}");
        }
        else
        {
            if (goal.IsCompleted)
                Console.WriteLine($"{goalNumber}. [X]{goal.Name} ({goal.Description})");
            else
                Console.WriteLine($"{goalNumber}. [ ]{goal.Name} ({goal.Description})");
        }
        goalNumber++;
    }
}
private static void DisplayScore()
{
    userScore = goals.Sum(g => g.CalculateScore());
    Console.WriteLine($"Your total score is: {userScore}");
}
private static void ExportGoalsToCSV(string filePath)
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



