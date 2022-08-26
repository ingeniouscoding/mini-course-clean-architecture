using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature;

internal class LowTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Temperature <= 0;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>
        {
            new PackingItem("Winter Jacket", 1),
            new PackingItem("Gloves", 2),
            new PackingItem("Hoodie", 1),
        };
}
