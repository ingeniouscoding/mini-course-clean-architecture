using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal;

internal class BasicPolicy : IPackingItemsPolicy
{
    private const uint maximumQuantityOfClothes = 7;

    public bool IsApplicable(PolicyData data)
        => true;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>
        {
            new PackingItem("Socks", Math.Min(data.Days, maximumQuantityOfClothes)),
            new PackingItem("T-Shirt", Math.Min(data.Days, maximumQuantityOfClothes)),
            new PackingItem("Passport", 1),
            new PackingItem("Towel", 1),
            new PackingItem("Toothbrush", 1),
            new PackingItem("Toothpaste", 1),
            new PackingItem("Phone Charger", 1),
        };
}
