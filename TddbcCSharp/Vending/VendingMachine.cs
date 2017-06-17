using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
	public class VendingMachine
	{

		Dictionary<DrinkKind , int> _drinkKinds = new Dictionary<DrinkKind , int>();

		public VendingMachine()
		{
		}

		public int CountKinds()
		{
			return _drinkKinds.Count;
		}

		public void AddDrinkKind(DrinkKind drink, int stockCount)
		{
			_drinkKinds.Add(drink, stockCount);
		}

		public List<DrinkKind> AllDrinkKinds()
		{
			return new List<DrinkKind>(_drinkKinds.Keys);
		}

		public int GetStockCount(DrinkKind drinks)
		{
			return _drinkKinds[drinks];
		}
	}
}

