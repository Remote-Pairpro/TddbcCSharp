using System;
using System.Collections.Generic;
using System.Linq;

namespace TddbcCSharp.Vending
{
    public class DrinkKindAndStocks
    {

        Dictionary<DrinkKind, int> _drinkKindAndStocks;

        public DrinkKindAndStocks()
        {
            initStock();
        }

        private void initStock()
        {
            _drinkKindAndStocks = new Dictionary<DrinkKind, int>();
            AddDrinkKind(new DrinkKind("コーラ", 120), 5);
        }

        public void Clear()
        {
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

        internal bool ExistsBy(string drinkName)
        {
            return _drinkKindAndStocks.ContainsKey(new DrinkKind(drinkName, 0));
        }

        internal DrinkKind Of(string drinkName)
        {
            return _drinkKindAndStocks.Keys
                .Where(drinkKind => drinkKind.Name == drinkName)
                .First();
        }

        internal void PopStock(string drinkName)
        {
            _drinkKindAndStocks[new DrinkKind(drinkName, 0)]--;
        }
    }
}

