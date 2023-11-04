using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        // Example prompts for the activities
        var breathingPrompts = new List<string> { "Breathe in", "Breathe out" };
        var reflectionPrompts = new List<string> { "What are you grateful for today?", "Think about a happy memory." };
        var listingPrompts = new List<string> { "List your favorite books.", "List your goals for this year." };

        // Create instances of the activities
        var breathingActivity = new BreathingActivity("Breathing", "Relax and take deep breaths.");
        var reflectionActivity = new ReflectionActivity("Reflection", "Reflect on your thoughts.", reflectionPrompts);
        var listingActivity = new ListingActivity("Listing", "List down your thoughts.", listingPrompts);

        // Start the activities
        breathingActivity.StartActivity();
        reflectionActivity.StartActivity();
        listingActivity.StartActivity();
    }
}
