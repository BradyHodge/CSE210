public class Goal
{
    public string Name { get; private set; }
    public int PointValue { get; private set; }
    public bool IsCompleted { get; protected set; }
    public string Description { get; private set; }

    public Goal(string name, int pointValue, string description)
    {
        Name = name;
        PointValue = pointValue;
        IsCompleted = false;
        Description = description;
    }

    public virtual void MarkAsComplete()
    {
        IsCompleted = true;
    }

    public virtual int CalculateScore()
    {
        return IsCompleted ? PointValue : 0;
    }

}
