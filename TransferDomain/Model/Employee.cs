using System;

namespace transfer.domain
{
	public class Employee
	{
		public String login { get; private set; }

		public Employee (String login)
		{
		}

		public override bool Equals(Object obj)
		{
			if (obj is Employee)
				return login == ((Employee) obj).login;
			return false;
		}

		public override int GetHashCode ()
		{
			return this.GetHashCode ();
		}
	}
}

