// For the "Showing Creativity and Exceeding Requirements" I made a file with every scripture mastery scripture in it and my program picks one from random each time it is run.


// Importing required thingys
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Declaring the Program class
public class Program 
{ 
    // Declaring a private thing of type Scripture
    private Scripture scriptureInstance;
    // Declaring a bool so I can see if the program is running
    private bool isRunning;

    
    public Program() 
    { 
        // Setting the isRunning  to true
        isRunning = true;
        // Start doing the program stuff
        initializeProgram();
    }

    private void initializeProgram() 
{
    List<string[]> scriptureLines = new List<string[]>();
    
    using (TextFieldParser parser = new TextFieldParser("ScriptureMastery.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true; // Handles quote stuff

        // Skip the header row (bc it's a hoe)
        parser.ReadLine();

        while (!parser.EndOfData)
        {
            scriptureLines.Add(parser.ReadFields());
        }
    }

    // get random number
    Random random = new Random();
    // get a random line from the list
    var parts = scriptureLines[random.Next(scriptureLines.Count)]; 

   // Split the reference part (e.g., John 3:16-17) to separate book name from chapter and verse numbers
var referenceParts = parts[1].Split(' ');

// Extract the last part which contains chapter and verse information (probably)
var chapterAndVerse = referenceParts[referenceParts.Length - 1];

// Join the earlier parts to get the book name UwU
var bookName = string.Join(" ", referenceParts.Take(referenceParts.Length - 1));

// Split to get chapter number from the chapter and verse information
var chapterNumber = int.Parse(chapterAndVerse.Split(':')[0]);

// Split to get verse numbers 
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

 //  Create a new scripture thing with the reference and words
    scriptureInstance = new Scripture(reference, words);
}

    // Method to display the menu to the user
    private void displayMenu() 
    { 
        Console.Clear();
        Console.WriteLine(scriptureInstance);
        Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
    }

    // Method to handle the user's input
    private void handleUserInput() 
    {
        var input = Console.ReadLine();
        if (input.ToLower() == "quit") 
        {
            // Setting isRunning to false to stop the program
            isRunning = false;
        } 
        else 
        {
            // hide some words
            scriptureInstance.HideRandomWords();
            if (scriptureInstance.AreAllWordsHidden()) 
            {
                Console.Clear();
                Console.WriteLine("All words are hidden. Press any key to exit.");
                // Waiting for a key press from the user (thanks stackoverflow)
                Console.ReadKey();
                isRunning = false;
            }
        }
    }

    // Method to terminate the program
    private void terminateProgram() 
    {
        // Printing a goodbye message to the user (bc we're nice like that)
        Console.WriteLine("Goodbye!");
    }

    // Run the program
    public void Run() 
    {
        // Running the program as long as isRunning is true
        while (isRunning) 
        {
            displayMenu();
            handleUserInput();
        }
        // Calling the terminateProgram when the program stops
        terminateProgram();
    }

    // Main method, the entry point of the program
    public static void Main(string[] args) 
    {
        // Creating a new instance of the Program class
        Program program = new Program();
        program.Run();
    }
}
