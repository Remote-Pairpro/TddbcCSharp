using System.Collections.Generic;
using System.Linq;

namespace TddbcCSharp.Vending
{
    internal class DrinkKindAndStocks
    {

        Dictionary<DrinkKind, int> _drinkKindAndStocks;

        internal DrinkKindAndStocks()
        {
            initStock();
        }

        private void initStock()
        {
            _drinkKindAndStocks = new Dictionary<DrinkKind, int>();
            AddDrinkKind(new DrinkKind("コーラ", 120), 5);
        }

        internal void Clear()
        {
            _drinkKindAndStocks.Clear();
        }

        internal int CountKinds()
        {
            return _drinkKindAndStocks.Count;
        }

        internal void AddDrinkKind(DrinkKind drink, int stockCount)
        {
            _drinkKindAndStocks.Add(drink, stockCount);
        }

        internal List<DrinkKind> AllDrinkKinds()
        {
            return new List<DrinkKind>(_drinkKindAndStocks.Keys);
        }

        internal int CountStockOf(DrinkKind drinkKind)
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

