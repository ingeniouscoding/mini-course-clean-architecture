using PackIT.Domain.Constants;
using PackIT.Domain.Entities;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

internal class PackingListFactory : IPackingListFactory
{
    public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
        => this.policies = policies;

    private readonly IEnumerable<IPackingItemsPolicy> policies;

    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        => new(id, name, localization);

    public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
        Temperature temperature, Localization localization)
    {
        PolicyData data = new(days, gender, temperature, localization);

        IEnumerable<IPackingItemsPolicy> applicablePolicies = policies.Where(p => p.IsApplicable(data));
        IEnumerable<PackingItem> items = applicablePolicies.SelectMany(p => p.GenerateItems(data));

        PackingList packingList = Create(id, name, localization);
        packingList.AddItems(items);

        return packingList;
    }
}
