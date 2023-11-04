using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> reflectionPrompts;

    public ReflectionActivity(string name, string description, List<string> prompts) : base(name, description)
    {
        reflectionPrompts = prompts;
    }

    public override void StartActivity()
    {
        DisplayStartingMessage();

        foreach (var prompt in reflectionPrompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(5000); // Give the user time to reflect
        }

        DisplayEndingMessage();
    }
}
