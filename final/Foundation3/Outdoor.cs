using System;

public class Outdoor : Event
{
    private string weatherForecast;

    public Outdoor(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public string WeatherForecast
    {
        get { return weatherForecast; }
        set { weatherForecast = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather Forecast: {weatherForecast}";
    }
}
