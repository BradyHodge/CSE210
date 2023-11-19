public class EternalGoal : Goal
{
    public int Occurrences { get; private set; }

    public EternalGoal(string name, int pointValue) : base(name, pointValue)
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
