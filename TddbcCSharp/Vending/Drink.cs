using System;

namespace TddbcCSharp.Vending
{
	public class Drink
	{

		private string _name;

		public Drink (string name, int price, int stockCount)	{
			_name = name;
		}

		public string name 
		{
			get { return this._name; }
		}

	}

}

