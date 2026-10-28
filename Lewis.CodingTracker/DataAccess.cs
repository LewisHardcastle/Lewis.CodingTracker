using System.Data.SQLite;

namespace Lewis.CodingTracker;

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }
}