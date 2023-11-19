public class ChecklistGoal : Goal
{
    public int CompletionCount { get; private set; }
    public int CompletionTarget { get; private set; }
    public int BonusPoints { get; private set; } 

    public ChecklistGoal(string name, int pointValue, int target, int bonusPoints) 
        : base(name, pointValue)
    {
        CompletionCount = 0;
        CompletionTarget = target;
        BonusPoints = bonusPoints; 
    }

    public void RecordCompletion()
    {
        if (CompletionCount < CompletionTarget)
        {
            CompletionCount++;
            if (CompletionCount == CompletionTarget)
            {
                MarkAsComplete();
            }
        }
    }

    public override int CalculateScore()
{
    if (IsCompleted)
    {
        return PointValue + BonusPoints;
    }
    else
    {
        return PointValue;
    }
}
}

