using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace TddbcCSharp.Vending
{
	public class DrinkKind
	{

		private string _name;

		public DrinkKind(string name, int price)
		{
			_name = name;
		}

		public string Name {
			get { return this._name; }
		}

		public override bool Equals(Object other)
		{
			if (other == null || !(other is DrinkKind))
				return false;
			DrinkKind otherDrink = (DrinkKind)other;
			return this.Name == otherDrink.Name;
		}

		public override int GetHashCode()
		{
			return _name.GetHashCode();
		}
	}

}

