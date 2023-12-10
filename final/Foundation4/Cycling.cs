using System;

public class Cycling : Activity
{

    private double speed;


    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }


    public double Speed
    {
        get { return speed; }
        set { speed = value; }
    }


    public override double GetDistance()
    {
    
        return speed * (Duration / 60.0);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
    
        if (speed == 0) return 0;
        return 60 / speed;
    }


    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Cycling ({Duration} min) - Distance: {GetDistance()} miles, Speed: {speed} mph, Pace: {GetPace()} min per mile";
    }
}
