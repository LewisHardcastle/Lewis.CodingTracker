using System.Globalization;

namespace Lewis.CodingTracker;

public class UserValidation
{
    // Validate date time format

    public SessionTimings DateTimeValidator(string userInputStartTimeStr, string userInputEndTimeStr)
    {

        var sessionTimings = new SessionTimings();

        DateTime startTime = DateTime.ParseExact(userInputStartTimeStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        DateTime endTime = DateTime.ParseExact(userInputEndTimeStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        TimeSpan duration = endTime - startTime;

        sessionTimings.StartTime = startTime;
        sessionTimings.EndTime = endTime;
        sessionTimings.Duration = duration;

        
        return sessionTimings;
    }

    // validate an ID is in the db
}