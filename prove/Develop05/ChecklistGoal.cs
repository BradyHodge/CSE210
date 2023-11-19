public class ChecklistGoal : Goal
{
    public int CompletionCount { get; private set; }
    public int CompletionTarget { get; private set; }

    public ChecklistGoal(string name, int pointValue, int target) : base(name, pointValue)
    {
        CompletionCount = 0;
        CompletionTarget = target;
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
        return PointValue * CompletionCount + (IsCompleted ? 100 : 0);
    }
}
