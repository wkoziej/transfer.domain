using System;

namespace transfer.domain
{
	public class TransferPositionFactory : GenericFactory<TransferPosition>
	{
		public TransferPositionFactory ()
		{
		}

		public override TransferPosition build() 
		{
			return new TransferPosition (null, null, 0);
		}


	}
}

