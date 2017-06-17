using System;

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

	}

}

