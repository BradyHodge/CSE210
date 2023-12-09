using System;

class Program
{
    static void Main(string[] args)
    {
        Address eventAddress = new Address("123 Event Street", "EventCity", "EventState", "EventCountry");

        Lecture lectureEvent = new Lecture(
            "Science of Artificial Intelligence",
            "A comprehensive lecture on AI and its applications.",
            new DateTime(2023, 12, 10),
            new TimeSpan(18, 30, 0),
            eventAddress,
            "Dr. Jane Smith",
            100);

        Reception receptionEvent = new Reception(
            "Annual Charity Gala",
            "An evening of elegance for a good cause.",
            new DateTime(2023, 12, 15),
            new TimeSpan(19, 0, 0),
            eventAddress,
            "rsvp@charitygala.org");

        Outdoor outdoorEvent = new Outdoor(
            "City Marathon",
            "Annual marathon through the heart of the city.",
            new DateTime(2023, 12, 20),
            new TimeSpan(7, 0, 0),
            eventAddress,
            "Sunny with mild temperatures");

        DisplayEventMarketing(lectureEvent);
        DisplayEventMarketing(receptionEvent);
        DisplayEventMarketing(outdoorEvent);
    }
    static void DisplayEventMarketing(Event eventObj)
    {
        Console.WriteLine("---- Event Marketing ----");
        Console.WriteLine("Standard Details:\n" + eventObj.GetStandardDetails());
        Console.WriteLine("Full Details:\n" + eventObj.GetFullDetails());
        Console.WriteLine("Short Description:\n" + eventObj.GetShortDescription());
        Console.WriteLine();
    }
}
