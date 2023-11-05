using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> reflectionPrompts;
    private List<string> reflectionQuestions;
    private Random random = new Random();

    public ReflectionActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        reflectionPrompts = prompts;
        reflectionQuestions = questions;
    }

    public override void StartActivity()
    {
        DisplayStartingMessage();

        // Select a random prompt from the list
        var prompt = reflectionPrompts[random.Next(reflectionPrompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        // Wait for user to press Enter and then display a random question
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
        var question = reflectionQuestions[random.Next(reflectionQuestions.Count)];
        Console.WriteLine(question);
        SpinningAnimation(10);
        }

        DisplayEndingMessage();
    }
}
