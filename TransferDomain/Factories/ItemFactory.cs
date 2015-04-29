using System;

namespace transfer.domain
{
	public class ItemFactory : GenericFactory<Item>
	{
		public ItemFactory ()
		{
		}

		public override Item build() 
		{
			return new Item ();
		}
	}
}

