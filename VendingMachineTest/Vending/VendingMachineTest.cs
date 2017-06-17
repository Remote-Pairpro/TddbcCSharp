using NUnit.Framework;
using System;
using TddbcCSharp.Vending;
using System.Collections.Generic;

namespace TddbcCSharpNUnit
{
	[TestFixture()]
	public class VendingMachineTest
	{

		private VendingMachine _sut;

		[SetUp]
		public void setUp()
		{
			_sut = new VendingMachine();	
		}

		// ---- Step0 ----

		[Test()]
		public void 未投入の場合は投入金額の総計が０である()
		{
			Assert.AreEqual(0, _sut.TotalAmount);
		}

		[Test()]
		public void 十円投入すると総計が十円となる()
		{
			// 実行
			_sut.Insert(10);
			// 確認
			Assert.AreEqual(10, _sut.TotalAmount);
		}

		[Test()]
		public void 五十円投入すると総計が五十円となる()
		{
			// 実行
			_sut.Insert(50);
			// 確認
			Assert.AreEqual(50, _sut.TotalAmount);
		}

		[Test()]
		public void 百円投入すると総計が百円となる()
		{
			// 実行
			_sut.Insert(100);
			// 確認
			Assert.AreEqual(100, _sut.TotalAmount);
		}

		[Test()]
		public void 複数回投入すると総計が取得できる()
		{
			// 実行
			_sut.Insert(10);
			_sut.Insert(50);
			// 確認
			Assert.AreEqual(60, _sut.TotalAmount);
		}

		[Test()]
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

		[Test()]
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

		[Test()]
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

		[Test()]
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

		[Test()]
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

		[Test()]
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

		[Test()]
		public void 初期状態でジュース1種類を格納している()
		{
			// 実行
			List<DrinkKind> actual = _sut.AllDrinkKinds();
			// 確認
			Assert.AreEqual(1, actual.Count);
		}

		[Test()]
		public void 初期状態でコーラを格納している()
		{
			// 実行
			List<DrinkKind> kinds = _sut.AllDrinkKinds();
			// 確認
			DrinkKind actual = kinds[0];
			Assert.AreEqual("コーラ", actual.Name);
		}

		[Test()]
		public void 初期状態で120円の飲み物を格納している()
		{
			// 実行
			List<DrinkKind> kinds = _sut.AllDrinkKinds();
			// 確認
			DrinkKind actual = kinds[0];
			Assert.AreEqual(120, actual.Price);
		}

		[Test()]
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
