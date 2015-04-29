using System;

namespace transfer.domain
{
	public class PlaceFactory : GenericFactory<Place>
	{
		public PlaceFactory ()
		{
		}

		public override Place build() 
		{
			return new Place ();
		}
	}
}

