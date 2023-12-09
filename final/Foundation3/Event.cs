using System;

public class Event
{

    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;


    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }


    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public TimeSpan Time
    {
        get { return time; }
        set { time = value; }
    }

    public Address EventAddress
    {
        get { return address; }
        set { address = value; }
    }


    public string GetStandardDetails()
    {
        return $"Event Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }


    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }


    public string GetShortDescription()
    {
        return $"Event: {title} on {date.ToShortDateString()}";
    }
}

