using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities;

public class PackingList : AggregateRoot<PackingListId>
{
    internal PackingList(PackingListId id, PackingListName name, Localization localiaztion)
    : base(id)
    {
        this.name = name;
        this.localiaztion = localiaztion;
    }

    private readonly PackingListName name;
    private readonly Localization localiaztion;
    private readonly LinkedList<PackingItem> items = new();

    public void AddItem(PackingItem item)
    {
        bool isAlreadyExists = items.Any(i => i.Name == item.Name);
        if (isAlreadyExists)
        {
            throw new PackingItemAlreadyExistsExeption(name, item.Name);
        }

        items.AddLast(item);
        AddEvent(new PackingItemAdded(this, item));
    }

    public void AddItems(IEnumerable<PackingItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void PackItem(string itemName)
    {
        PackingItem item = GetItem(itemName);
        PackingItem packedItem = item with { IsPacked = true };

        items.Find(item)!.Value = packedItem;
        AddEvent(new PackingItemAdded(this, item));
    }

    public void RemoveItem(string itemName)
    {
        PackingItem item = GetItem(itemName);
        items.Remove(item);
        AddEvent(new PackingItemRemoved(this, item));
    }

    private PackingItem GetItem(string itemName)
    {
        var item = items.SingleOrDefault(i => i.Name == itemName);
        if (item is null)
        {
            throw new PackingItemNotFoundException(itemName);
        }
        return item;
    }
}
