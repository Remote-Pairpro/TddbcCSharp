using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
	public class DrinkKindAndStocks
	{

		Dictionary<DrinkKind , int> _drinkKindAndStocks;

		public DrinkKindAndStocks()
		{
			initStock();
		}

		private void initStock() {
			_drinkKindAndStocks = new Dictionary<DrinkKind , int>();
			AddDrinkKind(new DrinkKind("コーラ", 120), 5);
		}

		public void Clear() {
			_drinkKindAndStocks.Clear();
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

		public int CountStockOf(DrinkKind drinkKind)
		{
			return _drinkKindAndStocks[drinkKind];
		}
	}
}

