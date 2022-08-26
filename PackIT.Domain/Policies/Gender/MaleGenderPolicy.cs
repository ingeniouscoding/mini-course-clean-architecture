using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal class MaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Gender is Constants.Gender.Male;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>
        {
            new PackingItem("Laptop", 1),
            new PackingItem("Beer", (uint) 3 * data.Days),
            new PackingItem("Book", (uint) Math.Ceiling((double) data.Days / 7)),
        };
}
