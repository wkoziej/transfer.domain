
using System;

namespace transfer.domain
{
	public class EmployeeFactory : GenericFactory<Employee>
	{
		private static Int64 counter;

		public EmployeeFactory ()
		{
		}

		public override Employee build() 
		{
			String id = counter.ToString();
			counter++;
			return new Employee (id);
		}

	}
}

