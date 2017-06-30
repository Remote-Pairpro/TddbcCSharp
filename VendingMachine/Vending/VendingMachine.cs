using System;
using System.Collections.Generic;
using VendingMachine.Vending;

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

        public int Insert(JapaneseMoney money)
        {
            if (!money.CanUse()) return money.Amount();
            _totalAmount += money.Amount();
            return 0;
        }

        public int Insert(int amount)
        {
            if (IsNotJapaneseMoney(amount)) return amount;
            return Insert(ToManey(amount));
        }

        public int PayBack()
        {
            int lastTotal = _totalAmount;
            _totalAmount = 0;
            return lastTotal;
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

        public bool CanBuy(string drinkName)
        {
            if (!_drinkKindAndStocks.ExistsBy(drinkName)) return false;
            DrinkKind drinkKind = _drinkKindAndStocks.Of(drinkName);
            return drinkKind.Price < _totalAmount
                && CountStockOf(drinkKind) > 0;
        }

        private bool IsNotJapaneseMoney(int amount)
        {
            return !Enum.IsDefined(typeof(JapaneseMoney), amount);
        }

        private JapaneseMoney ToManey(int amount)
        {
            return (JapaneseMoney)Enum.ToObject(typeof(JapaneseMoney), amount);
        }

        public bool Buy(string v)
        {
            throw new NotImplementedException();
        }
    }
}

