// Purpose:
//     Initialize the program. 
//     Display the main menu to the user. 
//     Handle user input and direct the flow of the program.
//     Create instances of other classes as needed.
//     Terminate the program.


// Behaviors:
//     displayMenu(): Display the main menu options to the user.
//     handleUserInput(): Take user input and call the appropriate methods or create instances of other classes based on the input.
//     initializeProgram(): Set up any initial configurations or objects needed for the program to run.
//     terminateProgram(): End the program gracefully, ensuring any necessary cleanup is done.

// Attributes: 
//    Scripture scriptureInstance: An instance of the Scripture class to manage the scripture-related functionalities.
//    bool isRunning: A boolean variable to keep track of whether the program is running or not.

// Data Types: 
//    isRunning: bool

// Default constructor to initialize the program.
// Importing required namespaces
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Declaring the Program class
public class Program 
{ 
    // Declaring a private field of type Scripture
    private Scripture scriptureInstance;
    // Declaring a private boolean field to check if the program is running
    private bool isRunning;

    // Default constructor for the Program class
    public Program() 
    { 
        // Setting the isRunning field to true
        isRunning = true;
        // Calling the initializeProgram method
        initializeProgram();
    }

    // Method to initialize the program
    private void initializeProgram() 
{
    List<string[]> scriptureLines = new List<string[]>();
    
    using (TextFieldParser parser = new TextFieldParser("ScriptureMastery.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true; // Handles quoted fields

        // Skip the header row
        parser.ReadLine();

        while (!parser.EndOfData)
        {
            scriptureLines.Add(parser.ReadFields());
        }
    }

    Random random = new Random();
    var parts = scriptureLines[random.Next(scriptureLines.Count)];

    var referenceParts = parts[1].Split(' ');
    var chapterAndVerse = referenceParts[referenceParts.Length - 1];
    var bookName = string.Join(" ", referenceParts.Take(referenceParts.Length - 1));
    var chapterNumber = int.Parse(chapterAndVerse.Split(':')[0]);
    var verseNumbers = chapterAndVerse.Split(':')[1].Split('-');

    Reference reference;
    if (verseNumbers.Length == 1) 
    { 
        reference = new Reference(bookName, chapterNumber, int.Parse(verseNumbers[0]));
    } 
    else 
    { 
        reference = new Reference(bookName, chapterNumber, int.Parse(verseNumbers[0]), int.Parse(verseNumbers[1]));
    }
    var scriptureText = parts[2];

    var verses = scriptureText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    var words = new List<Word>();

    foreach (var verse in verses) 
{
    var verseParts = verse.Split(' ');
    for (int i = 0; i < verseParts.Length; i++) 
    {
        words.Add(new Word(verseParts[i]));
    }
}


    scriptureInstance = new Scripture(reference, words);
}

    // Method to display the menu to the user
    private void displayMenu() 
    { 
        // Clearing the console
        Console.Clear();
        // Printing the scriptureInstance to the console
        Console.WriteLine(scriptureInstance);
        // Printing instructions to the user
        Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
    }

    // Method to handle the user's input
    private void handleUserInput() 
    {
        // Reading the user's input from the console
        var input = Console.ReadLine();
        // Checking if the user typed "quit" (case insensitive)
        if (input.ToLower() == "quit") 
        {
            // Setting isRunning to false to stop the program
            isRunning = false;
        } 
        else 
        {
            // Calling the HideRandomWords method of the scriptureInstance
            scriptureInstance.HideRandomWords();
            // Checking if all words are hidden
            if (scriptureInstance.AreAllWordsHidden()) 
            {
                // Clearing the console
                Console.Clear();
                // Informing the user that all words are hidden
                Console.WriteLine("All words are hidden. Press any key to exit.");
                // Waiting for a key press from the user
                Console.ReadKey();
                // Setting isRunning to false to stop the program
                isRunning = false;
            }
        }
    }

    // Method to terminate the program
    private void terminateProgram() 
    {
        // Printing a goodbye message to the user
        Console.WriteLine("Goodbye!");
    }

    // Method to run the program
    public void Run() 
    {
        // Running the program as long as isRunning is true
        while (isRunning) 
        {
            displayMenu();
            handleUserInput();
        }
        // Calling the terminateProgram method when the program stops
        terminateProgram();
    }

    // Main method, the entry point of the program
    public static void Main(string[] args) 
    {
        // Creating a new instance of the Program class
        Program program = new Program();
        // Running the program
        program.Run();
    }
}
