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
        // Each occurrence adds to the score, but the goal is never marked as completed
    }

    public override int CalculateScore()
    {
        // The score is the point value times the number of occurrences
        return PointValue * Occurrences;
    }
}
