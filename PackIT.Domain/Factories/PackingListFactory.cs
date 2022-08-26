using PackIT.Domain.Constants;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

internal class PackingListFactory : IPackingListFactory
{
    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
    {
        throw new NotImplementedException();
    }

    public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender, Temperature temperature)
    {
        throw new NotImplementedException();
    }
}
