using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
	public class VendingMachine
	{

		Dictionary<DrinkKind , int> _drinkKindAndStocks = new Dictionary<DrinkKind , int>();

		public VendingMachine()
		{
		}

		public int CountKinds()
		{
			return _drinkKindAndStocks.Count;
		}

		public void AddDrinkKind(DrinkKind drink, int stockCount)
		{
			_drinkKindAndStocks.Add(drink, stockCount);
		}

		public List<DrinkKind> AllDrinkKinds()
		{
			return new List<DrinkKind>(_drinkKindAndStocks.Keys);
		}

		public int GetStockCount(DrinkKind drinks)
		{
			return _drinkKindAndStocks[drinks];
		}
	}
}

