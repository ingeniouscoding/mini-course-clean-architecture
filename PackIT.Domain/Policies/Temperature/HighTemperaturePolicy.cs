using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal class HighTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Temperature > 0;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>
        {
            new PackingItem("Suncream", 1),
            new PackingItem("Beer", (uint) 3 * data.Days),
            new PackingItem("Book", (uint) Math.Ceiling((double) data.Days / 7)),
        };
}

