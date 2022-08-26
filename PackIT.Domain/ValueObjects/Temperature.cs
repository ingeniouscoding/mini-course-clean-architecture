namespace PackIT.Domain.ValueObjects;

public record Temperature
{
    public Temperature(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(Temperature temperature)
        => temperature.Value;

    public static implicit operator Temperature(double temperature)
        => new(temperature);
}
