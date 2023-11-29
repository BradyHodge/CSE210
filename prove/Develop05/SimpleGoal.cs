public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int pointValue, string description) : base(name, pointValue, description)
    {
    }

    public override void MarkAsComplete()
    {
        if (!IsCompleted)
        {
            base.MarkAsComplete();
        }
    }

}
