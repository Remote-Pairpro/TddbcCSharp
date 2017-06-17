using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
	public class VendingMachine
	{

		DrinkKindAndStocks _drinkKindAndStocks;

		public VendingMachine()
		{
			_drinkKindAndStocks = new DrinkKindAndStocks();
		}

		public int CountKinds()
		{
			return _drinkKindAndStocks.CountKinds();
		}

		public void AddDrinkKind(DrinkKind drink, int stockCount)
		{
			_drinkKindAndStocks.AddDrinkKind(drink, stockCount);
		}

		public List<DrinkKind> AllDrinkKinds()
		{
			return _drinkKindAndStocks.AllDrinkKinds();
		}

		public int GetStockCount(DrinkKind drinkKind)
		{
			return _drinkKindAndStocks.GetStockCount(drinkKind);
		}
	}
}

