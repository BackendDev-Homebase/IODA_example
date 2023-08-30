using IODA.Data;

namespace IODA.Adapters.Providers;

public class DataAccess
{
    private readonly string _path = Path.Combine(Environment.CurrentDirectory, "../IOADA.Aapters.Providers/visitorcounts.txt");

    public async Task<VisitorCounts> Load()
    {
        // Integration
        var lines = await File.ReadAllLinesAsync(_path);
        var visitorCounts = VisitorCounts.Create(lines);
        return visitorCounts;
    }

    public async Task Store(VisitorCounts visitorCounts)
    {
        // Integration
        var lines = visitorCounts.ToLines();
        await File.WriteAllLinesAsync(_path, lines);
    }
}
