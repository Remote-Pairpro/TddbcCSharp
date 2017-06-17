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
			Assert.AreEqual(1 , actual.Count);
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
		public void 初期状態で在庫を5本格納している()
		{
			List<DrinkKind> kinds = _sut.AllDrinkKinds();
			DrinkKind drinkKind = kinds[0];
			// 実行
			int actual =   _sut.CountStockOf(drinkKind);
			// 確認
			Assert.AreEqual(5, actual);
		}

	}
}
