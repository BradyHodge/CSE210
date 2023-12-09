using System;

public class Lecture : Event
{
    private string speakerName;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        this.speakerName = speakerName;
        this.capacity = capacity;
    }

    public string SpeakerName
    {
        get { return speakerName; }
        set { speakerName = value; }
    }

    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speakerName}\nCapacity: {capacity} attendees";
    }
}
