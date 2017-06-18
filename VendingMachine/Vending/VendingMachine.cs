using System;
using System.Collections.Generic;

namespace TddbcCSharp.Vending
{
    public class VendingMachine
    {

        int _totalAmount = 0;
        DrinkKindAndStocks _drinkKindAndStocks;

        public VendingMachine()
        {
            _drinkKindAndStocks = new DrinkKindAndStocks();
        }

        public int TotalAmount
        {
            get { return _totalAmount; }
        }

        public void Insert(int amount)
        {
            _totalAmount += amount;
        }

        public int PayBack()
        {
            int lastTotal = _totalAmount;
            _totalAmount = 0;
            return lastTotal;
            ;
        }

        public void ClearStocks()
        {
            _drinkKindAndStocks.Clear();
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

        public int CountStockOf(DrinkKind drinkKind)
        {
            return _drinkKindAndStocks.CountStockOf(drinkKind);
        }
    }
}

