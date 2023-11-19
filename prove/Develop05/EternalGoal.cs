public class EternalGoal : Goal
{
    public int Occurrences { get; private set; }

    public EternalGoal(string name, int pointValue, string description) : base(name, pointValue, description)
    {
        Occurrences = 0;
    }

    public void RecordOccurrence()
    {
        Occurrences++;
    }

    public override int CalculateScore()
    {
        return PointValue * Occurrences;
    }
}
