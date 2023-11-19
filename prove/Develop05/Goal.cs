public class Goal
{
    public string Name { get; private set; }
    public int PointValue { get; private set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int pointValue)
    {
        Name = name;
        PointValue = pointValue;
        IsCompleted = false;
    }

    public virtual void MarkAsComplete()
    {
        IsCompleted = true;
    }

    public virtual int CalculateScore()
    {
        return IsCompleted ? PointValue : 0;
    }

    // Additional methods can be added here for common goal functionalities
}
