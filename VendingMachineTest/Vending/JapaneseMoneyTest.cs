using NUnit.Framework;
using static VendingMachine.Vending.JapaneseMoney;
using static VendingMachine.Vending.JapaneseMoneySupport;

namespace VendingMachineTest.Vending
{
    [TestFixture]
    public class JapaneseMoneyTest
    {
        [Test]
        public void 自販機で使える硬貨紙幣を判別出来る()
        {
            一円玉.CanUse().Is(false);
            五円玉.CanUse().Is(false);
            十円玉.CanUse().Is(true);
            五十円玉.CanUse().Is(true);
            百円玉.CanUse().Is(true);
            五百円玉.CanUse().Is(true);
            千円札.CanUse().Is(true);
            五千円札.CanUse().Is(false);
            一万円札.CanUse().Is(false);
        }
    }
}
