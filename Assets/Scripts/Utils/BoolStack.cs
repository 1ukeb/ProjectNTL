// bool that is true when timer is above 0, but false when below 0
public class BoolStack
{
    // time remaining
    public float time { get; private set; }

    // add time to timer
    public bool Add()
    {
        this.time++;
        return this.time > 0;
    }

    public bool Remove()
    {
        this.time--;
        return this.time > 0;
    }
}
