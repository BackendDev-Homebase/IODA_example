using IODA.Data;

namespace IODA.Domain;

public static class BusinessLogic
{
    public static List<string> GetAllVisitors(VisitorCounts visitorCounts)
    {
        // Integration
        return visitorCounts.AllVisitors();
    }

    public static string GetGreetingMessage(VisitorCounts visitorCounts, string name)
    {
        // Integration
        if (!visitorCounts.Exists(name))
        {
            visitorCounts.Add(name);
            return GetGreetingMessage(0, name);
        }
        else
        {
            visitorCounts.Increase(name);
            int count = visitorCounts.Count(name);
            return GetGreetingMessage(count, name);
        }
    }

    public static void RemoveVistorsWithMoreThan(VisitorCounts visitorCounts, int visits)
    {
        // Integration
        visitorCounts.RemoveVisitorsWithMoreThan(visits);
    }

    internal static string GetGreetingMessage(int count, string name)
    {
        // Operation
        return count switch
        {
            0 => $"Hello, {name}!",
            < 4 => $"Welcome back, {name}!",
            _ => $"Hello, my good friend {name}!"
        };
    }
}
