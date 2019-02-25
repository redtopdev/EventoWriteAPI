
namespace Engaze.Evento.Contract
{
    public enum EventType
    {
        GENERAL = 1,        // Meeting with no specific category.
        GAMES,              //   Meeting up for Sports or Games.
        PARTY,              //   Meeting up for Party.
        OFFICIAL          //    Work related meeting.
    }

    public enum EventState
    {
        NOT_STARTED = 1,
        IN_PROGRESS,
        COMPLETED
    }

    public enum EventAcceptanceState
    {
        Pending = -1,
        Rejected = 0,
        Accepted
    }

    public enum TrackingStatus
    {
        NOT_STARTED = 1,
        IN_PROGRESS,
        COMPLETED
    }

    public enum RecurrenceFrequency
    {
        Daily = 1,  //Meeting which recurs daily.
        Weekly,     //Meeting which recurs weekly.
        Monthly,    //Meeting which recurs monthly
        Yearly,     //Meeting which recurs Yearly.
    }
}
