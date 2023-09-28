using System;

public class Job
// keep track of the job title, company name, start year, and end year
{
    public string jobTitle;
    public string companyName;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{jobTitle} ({companyName}) {_startYear}-{_endYear}");
    }
}