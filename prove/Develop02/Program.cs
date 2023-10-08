using System;
using System.Collections.Generic;
using System.IO;
// Showing Creativity and Exceeding Requirements:
// I added a feature that determines number of days that the user has journaled.
// This is printed to the console when the user loads entries from a file. 
// (You can find this in Journal.cs in the LoadFromFile method.)

public class Program
{
    // Create a static instance of the Journal class to manage journal operations throughout the program.
    static Journal journal = new Journal();

    public static void Main()
    {
        // Infinite loop to keep the program running until the user decides to exit.
        while (true)
        {
            DisplayMenu();
            HandleChoice();
        }
    }

    // Method to display the main menu options to the user.
    public static void DisplayMenu()
    {
        Console.WriteLine("1. Add Entry");
        Console.WriteLine("2. Display Entries");
        Console.WriteLine("3. Save to File");
        Console.WriteLine("4. Load from File");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }

    // Method to handle the user's choice from the main menu.
    public static void HandleChoice()
    {
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                // Get a random prompt from the journal and ask the user for a response.
                string randomPrompt = journal.GetRandomPrompt();
                Console.WriteLine($"Prompt: {randomPrompt}");
                Console.Write("Enter response: ");
                string response = Console.ReadLine();
                var entry = new Entry();
                entry.CreateEntry(randomPrompt, response); // Create a new entry with the prompt and response.
                journal.AddEntry(entry); // Add the new entry to the journal.
                break;
            case 2:
                // Display all the entries in the journal.
                journal.DisplayEntries();
                break;
            case 3:
                // Ask the user for a file path and save the journal entries to that file.
                Console.Write("Enter file path to save: ");
                string savePath = Console.ReadLine();
                journal.SaveToFile(savePath);
                break;
            case 4:
                // Ask the user for a file path and load journal entries from that file.
                Console.Write("Enter file path to load from: ");
                string loadPath = Console.ReadLine();
                journal.LoadFromFile(loadPath);
                break;
            case 5:
                // Exit the program.
                ExitProgram();
                break;
            default:
                // Handle invalid menu choices.
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    // Method to exit the program gracefully.
    public static void ExitProgram()
    {
        Console.WriteLine("Exiting program...");
        Environment.Exit(0); // Terminate the program.
    }
}