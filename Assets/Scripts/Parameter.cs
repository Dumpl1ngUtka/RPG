public class Parameter
{
    private float _value;
    public Parameter(float value)
    {
        _value = value;
    }

    public float Get()
    {
        return _value;
    }

    public void Set(float value)
    {
        _value = value;
    }
}
