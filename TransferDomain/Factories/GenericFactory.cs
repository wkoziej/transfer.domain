using System;

namespace transfer.domain
{
	public abstract class GenericFactory<Type>
	{
		public GenericFactory ()
		{
		}

		public abstract Type build();
	}
}

