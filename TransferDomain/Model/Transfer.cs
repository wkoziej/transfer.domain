using System;
using System.Collections.Generic;

namespace transfer.domain
{
	public class TransferNotAssignedException : Exception 
	{
	
	}

	public class TransferIsPerfomingException : Exception
	{
	}

	public class TransferPositionNotFoundException : Exception
	{
	}

	public class Transfer
	{


		private Employee assignee;
		private List<TransferPosition> positions;

		public Transfer ()
		{
			positions = new List<TransferPosition>();
		}
	
		public bool isAssigned()
		{
			return assignee != null;
		}

		public bool isAssignedTo(Employee employee) 
		{
			return employee == assignee;
		}

		public bool isPerforming()
		{
			return positions.Find(i => i.isPicked()) != null;
		}

		public void assignTo (Employee employee) 
		{
			if (isAssignedTo(employee)) 
				return;

			assignee = employee;
		}
	
		public void release ()
		{
			if (!isAssigned ())
				throw new TransferNotAssignedException ();

			if (isPerforming())
				throw new TransferIsPerfomingException();
			
			assignee = null;
		}

		public bool hasItemsToPick ()
		{
			return getNextPositionToPick () != null;
		}

		public void addPositionToPick(TransferPosition position)
		{
			positions.Add (new TransferPosition(position.item, position.sourcePlace, position.quantity));
		}

		public void pick (TransferPosition position)
		{
			TransferPosition pickedPosition = positions.Find(i => i.Equals(position));
			if (pickedPosition == null)
				throw new TransferPositionNotFoundException ();
			pickedPosition.markPick ();
		}

		public TransferPosition getNextPositionToPick ()
		{
			return positions.Find(i => i.isWaiting4Pick());
		}
	}
}

