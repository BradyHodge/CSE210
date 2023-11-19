public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int pointValue) : base(name, pointValue)
    {
    }

    public override void MarkAsComplete()
    {
        if (!IsCompleted)
        {
            base.MarkAsComplete();
        }
    }

    // The CalculateScore method from the base class is sufficient for this type
}
