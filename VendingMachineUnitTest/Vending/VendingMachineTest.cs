﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddbcCSharp.Vending
{
    [TestClass]
    public class VendingMachineTest
    {

        private VendingMachine _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new VendingMachine();
        }

        // ---- Step0 ----

        [TestMethod]
        public void 未投入の場合は投入金額の総計が０である()
        {
            Assert.AreEqual(0, _sut.TotalAmount);
        }

        [TestMethod]
        public void 十円投入すると総計が十円となる()
        {
            // 実行
            _sut.Insert(10);
            // 確認
            Assert.AreEqual(10, _sut.TotalAmount);
        }

        [TestMethod]
        public void 五十円投入すると総計が五十円となる()
        {
            // 実行
            _sut.Insert(50);
            // 確認
            Assert.AreEqual(50, _sut.TotalAmount);
        }

        [TestMethod]
        public void 百円投入すると総計が百円となる()
        {
            // 実行
            _sut.Insert(100);
            // 確認
            Assert.AreEqual(100, _sut.TotalAmount);
        }

        [TestMethod]
        public void 五百円投入すると総計が五百円となる()
        {
            // 実行
            _sut.Insert(500);
            // 確認
            Assert.AreEqual(500, _sut.TotalAmount);
        }

        [TestMethod]
        public void 千投入すると総計が千円となる()
        {
            // 実行
            _sut.Insert(1000);
            // 確認
            Assert.AreEqual(1000, _sut.TotalAmount);
        }

        [TestMethod]
        public void 複数回投入すると総計が取得できる()
        {
            // 実行
            _sut.Insert(10);
            _sut.Insert(50);
            // 確認
            Assert.AreEqual(60, _sut.TotalAmount);
        }

        [TestMethod]
        public void 硬貨を混ぜた複数回投入が出来て総合計が確認できる()
        {
            // 準備
            _sut.Insert(10);
            _sut.Insert(50);
            _sut.Insert(100);
            _sut.Insert(500);
            _sut.Insert(1000);
            _sut.Insert(10);
            _sut.Insert(50);
            _sut.Insert(100);
            _sut.Insert(500);
            _sut.Insert(1000);
            // 実行
            int actual = _sut.TotalAmount;
            // 確認
            Assert.AreEqual(3320, actual);
        }

        [TestMethod]
        public void 払い戻しで現在の総計が帰ってくる()
        {
            // 準備
            _sut.Insert(10);
            _sut.Insert(10);
            // 実行
            int actual = _sut.PayBack();
            // 確認
            Assert.AreEqual(20, actual);
        }

        [TestMethod]
        public void 払い戻しを行うと総計が0になる()
        {
            // 準備
            _sut.Insert(10);
            // 実行
            _sut.PayBack();
            // 確認
            Assert.AreEqual(0, _sut.TotalAmount);
        }

        // ---- Step2 ----

        [TestMethod]
        public void ジュースを一種類格納できる()
        {
            // 準備
            _sut.ClearStocks();
            DrinkKind drink = new DrinkKind("コーラ", 120);
            // 実行
            _sut.AddDrinkKind(drink, 5);
            // 確認
            Assert.AreEqual(1, _sut.CountKinds());
        }

        [TestMethod]
        public void 格納されているジュースを取得できる()
        {
            // 準備
            _sut.ClearStocks();
            DrinkKind drink = new DrinkKind("コーラ", 120);
            _sut.AddDrinkKind(drink, 5);
            // 実行
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            // 確認
            DrinkKind actual = kinds[0];
            Assert.AreEqual("コーラ", actual.Name);
        }

        [TestMethod]
        public void 格納されているジュースの価格が取得できる()
        {
            // 準備
            _sut.ClearStocks();
            DrinkKind drink = new DrinkKind("コーラ", 120);
            _sut.AddDrinkKind(drink, 5);
            // 実行
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            // 確認
            DrinkKind actual = kinds[0];
            Assert.AreEqual(120, actual.Price);
        }

        [TestMethod]
        public void 格納されているジュースの在庫数を取得できる()
        {
            // 準備
            _sut.ClearStocks();
            DrinkKind drink = new DrinkKind("コーラ", 120);
            _sut.AddDrinkKind(drink, 5);
            // 実行
            int actual = _sut.CountStockOf(drink);
            // 確認
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void 初期状態でジュース1種類を格納している()
        {
            // 実行
            List<DrinkKind> actual = _sut.AllDrinkKinds();
            // 確認
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void 初期状態でコーラを格納している()
        {
            // 実行
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            // 確認
            DrinkKind actual = kinds[0];
            Assert.AreEqual("コーラ", actual.Name);
        }

        [TestMethod]
        public void 初期状態で120円の飲み物を格納している()
        {
            // 実行
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            // 確認
            DrinkKind actual = kinds[0];
            Assert.AreEqual(120, actual.Price);
        }

        [TestMethod]
        public void 初期状態で在庫を5本格納している()
        {
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            DrinkKind drinkKind = kinds[0];
            // 実行
            int actual = _sut.CountStockOf(drinkKind);
            // 確認
            Assert.AreEqual(5, actual);
        }

    }
}
