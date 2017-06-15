using System;

namespace TddbcCSharp.Vending
{
	public class Drink
	{

		private string _name;
		private int _stockCount;

		public Drink (string name, int price, int stockCount)	{
			_name = name;
			_stockCount = stockCount;
		}

		public string Name
		{
			get { return this._name; }
		}

		public int StockCount
		{
			get {return _stockCount;}
		}

	}

}

