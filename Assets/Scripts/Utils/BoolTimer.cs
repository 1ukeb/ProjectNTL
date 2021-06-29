// bool that is true when timer is above 0, but false when below 0
public class BoolTimer
{
    // time remaining
    public float time { get; private set; }

    // add time to timer
    public bool AddTime(float time)
    {
        this.time += time;
        return this.time > 0;
    }

    public bool RemoveTime(float time)
    {
        this.time -= time;
        return this.time > 0;
    }
}
