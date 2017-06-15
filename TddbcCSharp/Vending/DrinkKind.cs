using System;

namespace TddbcCSharp.Vending
{
	public class DrinkKind
	{

		private string _name;
		private int _stockCount;

		public DrinkKind (string name, int price, int stockCount)
		{
			_name = name;
			_stockCount = stockCount;
		}

		public string Name {
			get { return this._name; }
		}

		public int StockCount {
			get { return _stockCount; }
		}

	}

}

