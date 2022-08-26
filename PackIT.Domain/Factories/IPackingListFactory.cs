﻿using PackIT.Domain.Constants;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;
internal interface IPackingListFactory
{
    PackingList Create(PackingListId id, PackingListName name, Localization localization);
    PackingList CreateWithDefaultItems(PackingListId id, PackingListName name,TravelDays days, Gender gender,
        Temperature temperature, Localization localization);
}