public struct Parameter
{
    public float Value { get; private set; }
    public float BonusValue { get; private set; }
    public Parameter(float value, float bonusValue = 0)
    {
        Value = value;
        BonusValue = bonusValue;
    }

    public float Get()
    {
        return Value + BonusValue;
    }

    public void SetValue(float newValue)
    {
        Value = newValue;
    }

    public void RemoveBonus()
    {
        BonusValue = 0;
    }
    public static Parameter operator +(Parameter a, float value)
    {
        return new Parameter(a.Value,a.BonusValue + value);
    }

    public static Parameter operator *(Parameter a, float value)
    {
        return new Parameter(a.Value, a.BonusValue + a.Value * (value - 1));
    }

    public static Parameter operator +(float value, Parameter a)
    {
        return new Parameter(a.Value, a.BonusValue + value);
    }

    public static Parameter operator *(float value, Parameter a)
    {
        return new Parameter(a.Value, a.BonusValue + a.Value * (value - 1));
    }
    public static bool operator >(Parameter a, float value)
    {
        return a.Get() > value;
    }
    public static bool operator <(Parameter a, float value)
    {
        return a.Get() < value;
    }

    public static bool operator >(float value, Parameter a)
    {
        return a.Get() < value;
    }
    public static bool operator <(float value, Parameter a)
    {
        return a.Get() > value;
    }
}
