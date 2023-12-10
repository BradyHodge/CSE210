using System;

public abstract class Activity
{

    private DateTime date; 
    private int duration;  


    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }


    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public int Duration
    {
        get { return duration; }
        set { duration = value; }
    }


    public abstract double GetDistance();
    public abstract double GetSpeed();   
    public abstract double GetPace();    


    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")}: {this.GetType().Name} ({duration} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
