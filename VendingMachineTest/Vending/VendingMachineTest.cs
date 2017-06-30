using NUnit.Framework;
using System.Collections.Generic;
using static VendingMachine.Vending.JapaneseMoney;

namespace TddbcCSharp.Vending
{
    [TestFixture]
    public class VendingMachineTest
    {

        private VendingMachine _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new VendingMachine();
        }

        // ---- Step0 (with Basic NUnit) ----

        [Test]
        public void 未投入の場合は投入金額の総計が０である()
        {
            Assert.AreEqual(0, _sut.TotalAmount);
        }

        [Test]
        public void 十円投入すると総計が十円となる()
        {
            // 実行
            _sut.Insert(十円玉);
            // 確認
            Assert.AreEqual(10, _sut.TotalAmount);
        }

        [Test]
        public void 五十円投入すると総計が五十円となる()
        {
            // 実行
            _sut.Insert(五十円玉);
            // 確認
            Assert.AreEqual(50, _sut.TotalAmount);
        }

        [Test]
        public void 百円投入すると総計が百円となる()
        {
            // 実行
            _sut.Insert(百円玉);
            // 確認
            Assert.AreEqual(100, _sut.TotalAmount);
        }

        [Test]
        public void 五百円投入すると総計が五百円となる()
        {
            // 実行
            _sut.Insert(五百円玉);
            // 確認
            Assert.AreEqual(500, _sut.TotalAmount);
        }

        [Test]
        public void 千投入すると総計が千円となる()
        {
            // 実行
            _sut.Insert(千円札);
            // 確認
            Assert.AreEqual(1000, _sut.TotalAmount);
        }

        [Test]
        public void 複数回投入すると総計が取得できる()
        {
            // 実行
            _sut.Insert(十円玉);
            _sut.Insert(五十円玉);
            // 確認
            Assert.AreEqual(60, _sut.TotalAmount);
        }

        [Test]
        public void 硬貨を混ぜた複数回投入が出来て総合計が確認できる()
        {
            // 準備
            _sut.Insert(十円玉);
            _sut.Insert(五十円玉);
            _sut.Insert(百円玉);
            _sut.Insert(五百円玉);
            _sut.Insert(千円札);
            _sut.Insert(十円玉);
            _sut.Insert(五十円玉);
            _sut.Insert(百円玉);
            _sut.Insert(五百円玉);
            _sut.Insert(千円札);
            // 実行
            int actual = _sut.TotalAmount;
            // 確認
            Assert.AreEqual(3320, actual);
        }

        [Test]
        public void 払い戻しで現在の総計が帰ってくる()
        {
            // 準備
            _sut.Insert(十円玉);
            _sut.Insert(十円玉);
            // 実行
            int actual = _sut.PayBack();
            // 確認
            Assert.AreEqual(20, actual);
        }

        [Test]
        public void 払い戻しを行うと総計が0になる()
        {
            // 準備
            _sut.Insert(十円玉);
            // 実行
            _sut.PayBack();
            // 確認
            Assert.AreEqual(0, _sut.TotalAmount);
        }

        // ---- Step1 (with NUnit3 Style) ----

        [Test]
        public void 一円玉を投入されたら釣り銭として戻される()
        {
            int actual = _sut.Insert(一円玉);
            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void 一円玉を投入されたら総計に加算されない()
        {
            _sut.Insert(一円玉);
            Assert.That(_sut.TotalAmount, Is.EqualTo(0));
        }

        [Test]
        public void 五円玉を投入されたら釣り銭として戻される()
        {
            int actual = _sut.Insert(五円玉);
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void 五円玉を投入されたら総計に加算されない()
        {
            _sut.Insert(五円玉);
            Assert.That(_sut.TotalAmount, Is.EqualTo(0));
        }

        [Test]
        public void 一万円札を投入されたら釣り銭として戻される()
        {
            int actual = _sut.Insert(一万円札);
            Assert.That(actual, Is.EqualTo(10000));
        }

        [Test]
        public void 一万円札を投入されたら総計に加算されない()
        {
            _sut.Insert(一万円札);
            Assert.That(_sut.TotalAmount, Is.EqualTo(0));
        }

        [Test]
        public void 日本の通貨紙幣以外を投入されたら釣り銭として戻される()
        {
            int actual = _sut.Insert(123);
            Assert.That(actual, Is.EqualTo(123));
        }

        [Test]
        public void 日本の通貨紙幣以外を投入されたら総計に加算されない()
        {
            _sut.Insert(123);
            Assert.That(_sut.TotalAmount, Is.EqualTo(0));
        }

        [Test]
        public void 自販機で使える日本の通貨紙幣を投入されたらお釣りは帰ってこない()
        {
            int actual = _sut.Insert(百円玉);
            Assert.That(actual, Is.EqualTo(0));
        }

        // ---- Step2 (with Chaining Assertion) ----

        [Test]
        public void ジュースを一種類格納できる()
        {
            // 準備
            _sut.ClearStocks();
            DrinkKind drink = new DrinkKind("コーラ", 120);
            // 実行
            _sut.AddDrinkKind(drink, 5);
            // 確認
            _sut.CountKinds().Is(1);
        }

        [Test]
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
            actual.Name.Is("コーラ");
        }

        [Test]
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
            actual.Price.Is(120);
        }

        [Test]
        public void 格納されているジュースの在庫数を取得できる()
        {
            // 準備
            _sut.ClearStocks();
            DrinkKind drink = new DrinkKind("コーラ", 120);
            _sut.AddDrinkKind(drink, 5);
            // 実行
            int actual = _sut.CountStockOf(drink);
            // 確認
            actual.Is(5);
        }

        [Test]
        public void 初期状態でジュース1種類を格納している()
        {
            // 実行
            List<DrinkKind> actual = _sut.AllDrinkKinds();
            // 確認
            actual.Count.Is(1);
        }

        [Test]
        public void 初期状態でコーラを格納している()
        {
            // 実行
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            // 確認
            DrinkKind actual = kinds[0];
            actual.Name.Is("コーラ");
        }

        [Test]
        public void 初期状態で120円の飲み物を格納している()
        {
            // 実行
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            // 確認
            DrinkKind actual = kinds[0];
            actual.Price.Is(120);
        }

        [Test]
        public void 初期状態で在庫を5本格納している()
        {
            List<DrinkKind> kinds = _sut.AllDrinkKinds();
            DrinkKind drinkKind = kinds[0];
            // 実行
            int actual = _sut.CountStockOf(drinkKind);
            // 確認
            actual.Is(5);
        }

        // ---- Step3 (with Chaining Assertion) ----

        [Test]
        public void 投入金額が十分で在庫もある場合コーラ購入可能が確認出来る()
        {
            _sut.Insert(五百円玉);
            bool actual = _sut.CanBuy("コーラ");
            actual.Is(true);
        }

        [Test]
        public void 投入金額不足なら在庫があっても購入不可であることが確認出来る()
        {
            _sut.Insert(百円玉);
            _sut.Insert(十円玉);
            bool actual = _sut.CanBuy("コーラ");
            actual.Is(false);
        }

        [Test]
        public void 投入金額が十分でも在庫が無いなら購入不可であることが確認出来る()
        {
            _sut.ClearStocks();
            _sut.AddDrinkKind(new DrinkKind("コーラ", 120), 0);

            _sut.Insert(百円玉);
            _sut.Insert(十円玉);
            _sut.Insert(十円玉);

            bool actual = _sut.CanBuy("コーラ");

            actual.Is(false);
        }

    }
}
