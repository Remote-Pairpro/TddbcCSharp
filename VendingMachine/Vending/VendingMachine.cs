using System;
using System.Collections.Generic;
using VendingMachine.Vending;

namespace TddbcCSharp.Vending
{
    public class VendingMachine
    {
        private readonly DrinkKindAndStocks _drinkKindAndStocks;

        public int TotalAmount { get; private set; } = 0;

        public int SaleAmount { get; private set; } = 0;

        public VendingMachine()
        {
            _drinkKindAndStocks = new DrinkKindAndStocks();
        }

        public int Insert(JapaneseMoney money)
        {
            if (!money.CanUse()) return money.Amount();
            TotalAmount += money.Amount();
            return 0;
        }

        public int Insert(int amount)
        {
            return IsNotJapaneseMoney(amount) ? amount : Insert(ToManey(amount));
        }

        public int PayBack()
        {
            var lastTotal = TotalAmount;
            TotalAmount = 0;
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
            var drinkKind = _drinkKindAndStocks.Of(drinkName);
            return drinkKind.Price < TotalAmount
                && CountStockOf(drinkKind) > 0;
        }

        public bool Buy(string drinkName)
        {
            if (!CanBuy(drinkName)) return false;
            DrinkKind drinkKind = _drinkKindAndStocks.Of(drinkName);
            _drinkKindAndStocks.PopStock(drinkKind);
            var price = drinkKind.Price;
            TotalAmount -= price;
            SaleAmount += price;
            return true;
        }

        private bool IsNotJapaneseMoney(int amount)
        {
            return !Enum.IsDefined(typeof(JapaneseMoney), amount);
        }

        private JapaneseMoney ToManey(int amount)
        {
            return (JapaneseMoney)Enum.ToObject(typeof(JapaneseMoney), amount);
        }

    }
}

