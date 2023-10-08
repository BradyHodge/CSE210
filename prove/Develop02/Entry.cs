using System;
using System.Collections.Generic;
using System.IO;

// Define a class named 'Entry' to represent a journal or log entry.
public class Entry
{
    // Property to store the prompt or question for the entry.
    public string Prompt { get; set; }

    // Property to store the response or answer to the prompt.
    public string Response { get; set; }

    // Property to store the date when the entry was created.
    public string Date { get; set; }

    // Method to create a new entry with a given prompt and response.
    public void CreateEntry(string prompt, string response)
    {
        // Assign the provided prompt to the 'Prompt' property.
        Prompt = prompt;

        // Assign the provided response to the 'Response' property.
        Response = response;

        // Assign the current date in "YYYY-MM-DD" format to the 'Date' property.
        Date = DateTime.Now.ToString("yyyy-MM-dd");
    }
}
