namespace IODA.Data;

public class VisitorCounts
{
    private Dictionary<string, int> _visitorCounts;

    private VisitorCounts()
    {
        // Operation
        _visitorCounts = new Dictionary<string, int>();
    }

    public static VisitorCounts Create(string[] lines)
    {
        // Operation
        var result = new VisitorCounts
        {
            _visitorCounts = lines.ToDictionary(line => line.Split(' ')[0], line => int.Parse(line.Split(' ')[1]))
        };
        return result;
    }

    public string[] ToLines()
    {
        // Operation
        return _visitorCounts.Select(kvp => $"{kvp.Key} {kvp.Value}")
            .ToArray();
    }

    public bool Exists(string visitor)
    {
        // Operation
        return _visitorCounts.ContainsKey(visitor);
    }

    public int Count(string visitor)
    {
        // Operation
        return _visitorCounts[visitor];
    }

    public void Increase(string visitor)
    {
        // Operation
        _visitorCounts[visitor] += 1;
    }

    public void Add(string visitor)
    {
        // Operation
        _visitorCounts.Add(visitor, 1);
    }

    public List<string> AllVisitors()
    {
        // Operation
        return _visitorCounts.Keys.ToList();
    }

    public void RemoveVisitorsWithMoreThan(int visits)
    {
        // Operation
        foreach (var kvp in _visitorCounts)
        {
            if (kvp.Value > visits)
            {
                _visitorCounts.Remove(kvp.Key);
            }
        }
    }
}
