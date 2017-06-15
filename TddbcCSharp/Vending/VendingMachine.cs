using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
	public class VendingMachine
	{

		List<Drink> _drinkKinds = new List<Drink>();

		public VendingMachine ()
		{
		}

		public int CountKinds()
		{
			return _drinkKinds.Count;
		}

		public void AddDrinkKind(Drink drink)
		{
			_drinkKinds.Add (drink);
		}

		public List<Drink> AllDrinkKinds ()
		{
			return new List<Drink>(_drinkKinds);
		}
	}
}

