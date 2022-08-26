using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListIdException : PackItException
{
	public EmptyPackingListIdException() : base("packing list ID con not be empty")
	{
	}
}
