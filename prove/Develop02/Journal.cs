using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    // A list of prompts/questions for the journal entries.
    private List<string> prompts = new List<string>
    {
    "What was the highlight of your day?",
    "What's something new you learned today?",
    "Describe a challenge you faced today and how you overcame it.",
    "What are you grateful for today?",
    "Who made you smile today and why?",
    "What's something you wish you had done differently today?",
    "Describe a moment today when you felt proud of yourself.",
    "What's one thing you want to accomplish tomorrow?",
    "How did you take care of yourself today?",
    "What's a goal you're working towards and how did you make progress on it today?",
    "How did you feel when you woke up this morning?",
    "What's a memory from today that you want to remember a year from now?",
    "Who did you connect with today and what did you talk about?",
    "What's something unexpected that happened today?",
    "How did you relax and unwind today?",
    "What's a book, movie, or song that influenced your thoughts today?",
    "Describe a kind gesture someone did for you today.",
    "What's a new idea or inspiration you had today?",
    "How did today's weather affect your mood and activities?",
    "What's a habit you're trying to develop and how did you work on it today?",
    "Did you have any 'aha' moments or realizations today?",
    "What's something you're looking forward to in the near future?",
    "How did you express kindness or compassion today?",
    "What's a question you had today that you didn't find an answer to?",
    "Describe a moment today when you felt at peace.",
    "How did you step out of your comfort zone today?",
    "What's a lesson you learned from a mistake you made today?",
    "How did you practice self-love or self-care today?",
    "What's something you're curious about and want to learn more about?",
    "Describe a conversation you had today that had an impact on you.",
    "How did you spend your free time today?",
    "What's a goal you set for yourself today and did you achieve it?",
    "How did you handle stress or anxiety today?",
    "What's something you're excited about for tomorrow?",
    "Describe a moment of laughter or joy you experienced today.",
    "How did you contribute to someone else's happiness or well-being today?",
    "What's a positive change you noticed in yourself recently?",
    "How did you practice mindfulness or presence today?",
    "What's something you did today that aligned with your values or beliefs?",
    "Describe a beautiful moment or scene you witnessed today.",
    "How did you prioritize your tasks and responsibilities today?",
    "What's a dream or aspiration you had on your mind today?",
    "How did you nurture your physical, emotional, or spiritual well-being today?",
    "What's a piece of advice you received or gave today?",
    "Describe a moment of creativity or inspiration you had today.",
    "How did you connect with nature today?",
    "What's a decision you made today and how do you feel about it?",
    "How did you practice patience or resilience today?",
    "What's something you want to remember about today?",
    "Describe a moment today when you felt connected to something bigger than yourself."
    };

    // Random object to generate random numbers for selecting prompts.
    private Random random = new Random();

    // Method to get a random prompt from the list.
    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    // Property to store all the journal entries.
    public List<Entry> Entries { get; set; } = new List<Entry>();

    // Method to add a new journal entry to the list.
    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    // Method to display all the journal entries.
    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine($"Date: {entry.Date} \nPrompt: {entry.Prompt} \nResponse: {entry.Response}\n");
        }
    }

    // Method to save all the journal entries to a file.
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    //Method to load journal entries from a file.
    public void LoadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            List<string> daysJournaledList = new List<string> {};
            int daysJournaled = 0;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                var entry = new Entry
                {
                    Date = parts[0],
                    Prompt = parts[1],
                    Response = parts[2],
                    
                };
                Entries.Add(entry);
                string Date = parts[0];
                if (daysJournaledList.Contains(Date))
                {
                    break;
                }
                else
                {
                    daysJournaledList.Add(Date);
                    daysJournaled++;
                    
                }
            }
            Console.WriteLine($"Entries from {daysJournaled} different days ");
        }
    }
}