using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
	public class VendingMachine
	{

		List<DrinkKind> _drinkKinds = new List<DrinkKind>();

		public VendingMachine()
		{
		}

		public int CountKinds()
		{
			return _drinkKinds.Count;
		}

		public void AddDrinkKind(DrinkKind drink)
		{
			_drinkKinds.Add(drink);
		}

		public List<DrinkKind> AllDrinkKinds()
		{
			return new List<DrinkKind>(_drinkKinds);
		}
	}
}

