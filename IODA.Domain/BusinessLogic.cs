using IODA.Data;

namespace IODA.Domain;

public static class BusinessLogic
{
    public static List<string> GetAllUsers(UserCounts userCounts)
    {
        // Integration
        return userCounts.AllUsers();
    }

    public static string GetGreetingMessage(UserCounts userCounts, string name)
    {
        // Integration
        if (!userCounts.Exists(name))
        {
            userCounts.Add(name);
            return GetGreetingMessage(0, name);
        }
        else
        {
            userCounts.Increase(name);
            int count = userCounts.Count(name);
            return GetGreetingMessage(count, name);
        }
    }

    public static void RemoveUsersWithMoreThan(UserCounts userCounts, int visits)
    {
        // Integration
        userCounts.RemoveUsersWithMoreThan(visits);
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
