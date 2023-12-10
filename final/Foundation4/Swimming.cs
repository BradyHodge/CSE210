using System;

public class Swimming : Activity
{
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    private int laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }

    public override double GetDistance()
    {

        return laps * LapLengthMeters * MetersToMiles;
    }

    public override double GetSpeed()
    {

        double distanceMiles = GetDistance();
        return distanceMiles / (Duration / 60.0);
    }

    public override double GetPace()
    {

        double distanceMiles = GetDistance();
        if (distanceMiles == 0) return 0;
        return Duration / distanceMiles;
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Swimming ({Duration} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
