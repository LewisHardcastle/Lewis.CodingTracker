using System.Data.SQLite;
using System.Globalization;
using Dapper;

namespace Lewis.CodingTracker;

public class DataAccess
{
    private readonly string _connectionString;
    private UserValidation _userValidation;

    public DataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    // Create record of a coding session
    public void CreateCodingSession(string startTimeStr, string endTimeStr)
    {
        var validatedSessionTimings = _userValidation.DateTimeValidator(startTimeStr, endTimeStr);
        
        using (var connection = new SQLiteConnection(_connectionString))
        {
            var sql = "INSERT INTO CodingSessions (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration);";

            connection.Execute(sql, new 
            { 
                StartTime = validatedSessionTimings.StartTime.ToString(), 
                EndTime = validatedSessionTimings.EndTime.ToString(), 
                Duration = validatedSessionTimings.Duration.ToString() 
            });
        }

        Console.WriteLine("New Coding Session added to the list");
    }
    
    
    // Read coding sessions
    public void ReadCodingSessions()
    {
        IEnumerable<CodingSession> codingSessions;

        using (var connection = new SQLiteConnection(_connectionString))
        {
            var sql = "SELECT * FROM CodingSessions;";

            // Store the result of executing the above query on the db
            codingSessions = connection.Query<CodingSession>(sql);
        }

        foreach (var codingSession in codingSessions)
        {
            Console.WriteLine($"Session Number: {codingSession.Id} Start time: {codingSession.sessionTimings.StartTime} End time: {codingSession.sessionTimings.EndTime} Duration: {codingSession.sessionTimings.Duration}");
        }
    }
    
    // Update a coding session start time or end time
    
    public void UpdateCodingSession(int id, string newStartTimeStr, string newEndTimeStr)
    {
        // Add validation in a separate file for user input

        var validatedSessionTimings = _userValidation.DateTimeValidator(newStartTimeStr, newEndTimeStr);
        
        using (var connection = new SQLiteConnection(_connectionString))
        {
            var sql = "UPDATE CodingSessions SET StartTime = @StartTime, EndTime = @EndTime, Duration = @Duration WHERE Id = @Id;";

            connection.Execute(sql, new 
            { 
                StartTime = validatedSessionTimings.StartTime.ToString(), 
                EndTime = validatedSessionTimings.EndTime.ToString(), 
                Duration = validatedSessionTimings.Duration.ToString(),
                Id = id
            });
        }

        Console.WriteLine($"Coding Session {id} was updated.");
    }
    
    // delete a record
    public void DeleteCodingSession(int id)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            var sql = "DELETE FROM CodingSessions WHERE Id = @Id;";

            // Delete coding session
            connection.Query(sql, new
            {
                Id = id
            });
        }

        Console.WriteLine($"Coding session {id} was deleted.");
    }
}