using System;

namespace transfer.domain
{
	public class TransferPosition
	{
		enum Status {
			Wait4Pick,
			Picked
		};

		private Status status;

		public Item item { get; private set; }

		public Place sourcePlace { get; private set; }

		public Double quantity { get; private set; }

		public TransferPosition (Item item, Place sourcePlace, Double quantity)
		{
			this.item = item;
			this.sourcePlace = sourcePlace;
			this.quantity = quantity;
			status = Status.Wait4Pick;	
		}

		public void markPick ()
		{
			status = Status.Picked;
		}

		public bool isPicked()
		{
			return status == Status.Picked; 
		}

		public bool isWaiting4Pick ()
		{
			return status == Status.Wait4Pick;
		}

		public override bool Equals(Object obj)
		{
			if (obj is TransferPosition) {
				TransferPosition position = (TransferPosition) obj;
				return position.item.Equals (item)
					&& position.sourcePlace.Equals(sourcePlace)
					&& status.Equals(status);
			}
			return false;
		}
	}
}

