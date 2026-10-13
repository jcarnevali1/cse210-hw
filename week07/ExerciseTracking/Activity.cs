public abstract class Activity
{
    private DateTime _time;
    private int _minutes;

    public Activity(DateTime time, int minutes)
    {
        _time = time;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_time:dd MMM yyyy} ({_minutes} min): Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}