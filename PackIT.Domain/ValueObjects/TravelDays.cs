using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public record TravelDays
{
    public TravelDays(ushort value)
    {
        if (value is 0 || value > 100)
        {
            throw new InvalidTravelDaysException(value);
        }

        Value = value;
    }

    public ushort Value { get; }

    public static implicit operator ushort(TravelDays days)
        => days.Value;

    public static implicit operator TravelDays(ushort days)
        => new(days);
}
