using System;

namespace transfer.domain
{
	public class TransferFactory : GenericFactory<Transfer>
	{
		public TransferFactory ()
		{
		}

		public override Transfer build() 
		{
			return new Transfer ();
		}
	}
}

