﻿using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListNameException : PackItException
{
	public EmptyPackingListNameException() : base("packing list name can not be empty")
	{
	}
}
