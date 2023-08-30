namespace IODA.Data;

public class UserCounts
{
    private Dictionary<string, int> _userCounts;

    private UserCounts()
    {
        // Operation
        _userCounts = new Dictionary<string, int>();
    }

    public static UserCounts Create(string[] lines)
    {
        // Operation
        var result = new UserCounts
        {
            _userCounts = lines.ToDictionary(line => line.Split(' ')[0], line => int.Parse(line.Split(' ')[1]))
        };
        return result;
    }

    public string[] ToLines()
    {
        // Operation
        return _userCounts.Select(entry => $"{entry.Key} {entry.Value}")
            .ToArray();
    }

    public bool ExistsUser(string user)
    {
        // Operation
        return _userCounts.ContainsKey(user);
    }

    public int GetCount(string user)
    {
        // Operation
        return _userCounts[user];
    }

    public void Increase(string user)
    {
        // Operation
        _userCounts[user] += 1;
    }

    public void Add(string name)
    {
        // Operation
        _userCounts.Add(name, 1);
    }

    public List<string> AllUsers()
    {
        // Operation
        return _userCounts.Keys.ToList();
    }

    public void RemoveUsersWithMoreThan(int visits)
    {
        // Operation
        foreach (var kvp in _userCounts)
        {
            if (kvp.Value > visits)
            {
                _userCounts.Remove(kvp.Key);
            }
        }
    }
}
