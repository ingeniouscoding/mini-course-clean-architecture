using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class PackingItemAlreadyExistsExeption : PackItException
{
    public PackingItemAlreadyExistsExeption(string listName, string itemName)
        : base($"Packing list: '{listName}' already difined item {itemName}")
    {
        ListName = listName;
        ItemName = itemName;
    }

    public string ListName { get; }
    public string ItemName { get; }
}
