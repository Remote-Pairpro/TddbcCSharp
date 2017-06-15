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
			DrinkKind drink = new DrinkKind("コーラ", 120, 5);
			// 実行
			_sut.AddDrinkKind(drink);
			// 確認
			Assert.AreEqual(1, _sut.CountKinds());
		}

		[Test()]
		public void 格納されているジュースを取得できる()
		{
			// 準備
			DrinkKind drink = new DrinkKind("コーラ", 120, 5);
			_sut.AddDrinkKind(drink);
			// 実行
			List<DrinkKind> kinds = _sut.AllDrinkKinds();
			// 確認
			DrinkKind actual = kinds[0];
			Assert.AreEqual("コーラ", actual.Name);
		}

		[Test()]
		public void 格納されているジュースの在庫数を取得できる()
		{
			// 準備
			DrinkKind drink = new DrinkKind("コーラ", 120, 5);
			_sut.AddDrinkKind(drink);
			// 実行
			List<DrinkKind> kinds = _sut.AllDrinkKinds();
			// 確認
			DrinkKind actual = kinds[0];
			Assert.AreEqual(5, actual.StockCount);
		}

	}
}
