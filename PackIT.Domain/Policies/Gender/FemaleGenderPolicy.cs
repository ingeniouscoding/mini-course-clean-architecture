using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender;

internal class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Gender is Constants.Gender.Female;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>
        {
            new PackingItem("Lipstick", 1),
            new PackingItem("Eyeliner", 2),
            new PackingItem("Book", 2),
        };
}
