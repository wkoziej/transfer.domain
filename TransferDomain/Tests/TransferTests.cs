using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using transfer.domain;
//using testmvc.Controllers;

namespace transfer.domain
{
	[TestFixture]
	public class TransferTests
	{
		TransferFactory transferFactory;
		EmployeeFactory employeeFactory;
		ItemFactory itemFactory;
		PlaceFactory placeFactory;

		[SetUp] public void Init()
		{
			transferFactory = new TransferFactory ();	
			employeeFactory = new EmployeeFactory ();
			itemFactory = new ItemFactory ();
			placeFactory = new PlaceFactory ();
		}

		[Test]
		public void AddPickPositionToTransferTest()
		{
			var transfer = transferFactory.build ();
			var item = itemFactory.build ();
			var quantity = 1.0;
			var place = placeFactory.build ();

			var itemToPick = new TransferPosition (item, place, quantity);

			transfer.addPositionToPick (itemToPick);

			Assert.IsTrue (transfer.hasItemsToPick ());

			var nextItemToPick = transfer.getNextPositionToPick ();

			Assert.AreEqual (nextItemToPick, itemToPick);
		}

		[Test]
		public void AssignOperatorToTransferTest ()
		{
			var transfer = transferFactory.build ();
			var employee1 = employeeFactory.build (); 
			var employee2 = employeeFactory.build (); 

			Assert.IsFalse (transfer.isAssigned());
			Assert.IsFalse (transfer.isAssignedTo (employee1));

			transfer.assignTo (employee1);

			Assert.IsTrue (transfer.isAssigned());
			Assert.IsTrue (transfer.isAssignedTo(employee1));
			Assert.IsFalse (transfer.isAssignedTo(employee2));
		}

		[Test]
		public void ReleaseTransferTest ()
		{
			var transfer = transferFactory.build ();
			var employee = employeeFactory.build (); 
			var item = itemFactory.build ();
			var quantity = 1.0;
			var place = placeFactory.build ();
			var itemToPick = new TransferPosition (item, place, quantity);

			Assert.Throws<TransferNotAssignedException> (delegate { transfer.release (); } ); 

			transfer.assignTo (employee);

			Assert.DoesNotThrow ( delegate { transfer.release (); } ); 

			transfer.assignTo (employee);

			transfer.addPositionToPick (itemToPick);
			transfer.pick (itemToPick);

			Assert.Throws<TransferIsPerfomingException> (delegate { transfer.release ();} ); 

		}

		[Test]
		public void ExecuteTransferTest() {
		
			var transfer = transferFactory.build ();
			var employee = employeeFactory.build (); 
			var item1 = itemFactory.build ();
			var quantity1 = 1.0;
			var place1 = placeFactory.build ();
			var item2 = itemFactory.build ();
			var quantity2 = 1.0;
			var place2 = placeFactory.build ();

			var item1ToPick = new TransferPosition (item1, place1, quantity1);
			var item2ToPick = new TransferPosition (item2, place2, quantity2);


		}
	}
}
