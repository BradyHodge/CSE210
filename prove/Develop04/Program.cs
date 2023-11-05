using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        while (true)
        {
            DisplayMenu();
            HandleChoice();
        }
    }
    public static void DisplayMenu()
    {
        Console.WriteLine("1. Start the Breathing Activity");
        Console.WriteLine("2. Start the Reflection Activity");
        Console.WriteLine("3. Start the Listing Activity");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
    }
    public static void HandleChoice()
    {
        var breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing breathing in and out slowly. Clear your mind and focus on your breathing.");
        var reflectionPrompts = new List<string> 
        { 
            "Reflect on a moment you felt most alive.",
            "Consider the most valuable lesson you've learned from a mistake.",
            "Think about a person who has had a significant impact on your life.",
            "Recall a situation where you had to show courage.",
            "Ponder on an achievement that you are most proud of.",
            "Remember a time when you helped someone in need.",
            "Contemplate the hardest decision you ever had to make.",
            "Imagine how you would like to be remembered by your loved ones.",
            "Mull over a turning point in your life that led you to where you are now.",
            "Focus on a moment of unexpected kindness you received or gave.",
            "Recollect a period of your life that you would consider your 'golden age'.",
            "Think back to a challenge that taught you a valuable lesson.",
            "Dwell on the changes you have noticed in yourself over the past five years.",
            "Reflect on the aspects of your life that you are most grateful for.",
            "Consider the ways in which you have grown from your experiences.",
            "Think of a goal you achieved that once seemed impossible.",
            "Recall a moment when you felt complete peace and contentment.",
            "Ponder on the times when you've had to adapt to unexpected changes.",
            "Contemplate a relationship that has greatly influenced your life.",
            "Meditate on how you've made a positive impact in someone's life."
        };
        var reflectionQuestions = new List<string>
        {
            "What emotions did you feel during this experience?",
            "How did this experience shape who you are today?",
            "What did you learn about yourself from this?",
            "How has this moment changed your perspective on life?",
            "What would you have done differently, if given the chance?",
            "Why do you think this experience stands out in your memory?",
            "What skills or strengths did you discover about yourself through this?",
            "How did this experience influence your future choices?",
            "What do you think this says about your values and priorities?",
            "In what ways did this experience challenge your beliefs?",
            "How did you grow from this experience?",
            "What was the most surprising aspect of this experience?",
            "Who or what was instrumental in helping you through this time?",
            "What was the support system like for you during this period?",
            "In what ways have you been able to pass on the lessons from this experience to others?",
            "How did this experience contribute to your goals or life plan?",
            "What would you tell someone else going through a similar situation?",
            "How do you think this experience has impacted your relationships with others?",
            "What kind of legacy do you think this experience will leave on your life?",
            "If you could relive this moment, what would you savor or pay more attention to?"
        };
        var listingPrompts = new List<string> 
        {
            "What moments from today were most meaningful to you?",
            "How have you seen personal growth this week?",
            "What challenges have you overcome this month?",
            "What has brought you joy in the past week?",
            "How have you helped others recently?",
            "What lessons have you learned from the events of this month?",
            "In what ways have you pushed yourself out of your comfort zone lately?",
            "What accomplishments are you proud of this week?",
            "How have you made progress on your goals?",
            "What are you most grateful for today?",
            "How have you contributed to your community or network this month?",
            "What has been your most significant learning this week?",
            "How have you managed stress on challenging days?",
            "What new connections or relationships have you fostered recently?",
            "In what ways have you experienced personal success or failure?",
            "How have you made use of your talents and skills this week?",
            "What habits have you adopted or changed lately?",
            "How have you dealt with setbacks this month?",
            "What moments of self-care have you prioritized recently?",
            "When have you felt most connected with your surroundings?"
        };
        var reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", reflectionPrompts, reflectionQuestions);
        var listingActivity = new ListingActivity("Listing", "List down your thoughts.", listingPrompts);

        int choice = 4;
        try
        {
            choice = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            
            Console.WriteLine("Invalid choice. Try again.");
            return;
        }

        switch (choice)
        {
            case 1:
                breathingActivity.StartActivity();
                break;
            case 2:
                reflectionActivity.StartActivity();
                break;
            case 3:
                listingActivity.StartActivity();
                break;
            case 4:
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }

    }
}
