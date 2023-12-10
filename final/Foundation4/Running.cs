using System;

public class Running : Activity
{

    private double distance;


    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }


    public double Distance
    {
        get { return distance; }
        set { distance = value; }
    }


    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
    
        return distance / (Duration / 60.0);
    }

    public override double GetPace()
    {
    
        if (distance == 0) return 0;
        return Duration / distance;
    }


    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Running ({Duration} min) - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
