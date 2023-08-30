using IODA.Data;

namespace IODA.Adapters.Providers;

public class DataAccess
{
    private readonly string _path = Path.Combine(Environment.CurrentDirectory, "../IOADA.Aapters.Providers/usercounts.txt");

    public async Task<UserCounts> Load()
    {
        // Integration
        var lines = await File.ReadAllLinesAsync(_path);
        var userCounts = UserCounts.Create(lines);
        return userCounts;
    }

    public async Task Store(UserCounts userCounts)
    {
        // Integration
        var lines = userCounts.ToLines();
        await File.WriteAllLinesAsync(_path, lines);
    }
}
