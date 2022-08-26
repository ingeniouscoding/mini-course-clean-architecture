﻿namespace PackIT.Domain.ValueObjects;

public record Localization(string City, string Country)
{
    public static Localization Create(string value)
    {
        string[] splitLocalization = value.Split(',');
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString()
        => $"{City}, {Country}";
}