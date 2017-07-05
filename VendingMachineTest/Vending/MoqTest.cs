using Moq.Protected;
using Moq;
using NUnit.Framework;
using static VendingMachine.Vending.JapaneseMoney;
using static VendingMachine.Vending.JapaneseMoneySupport;

namespace VendingMachineTest.Vending
{

    public class CTest
    {
        //        public string TestTest(string test)
        //        {
        //            return "abc";
        //        }

        public virtual string TestTest(string test) {
            return "";
        }

        public string Foo(string test)
        {
            return this.TestTest(test);
        }

    }

    [TestFixture]
    public class MoqTest
    {


        [Test]
        public void Moqtesuto()
        {
            Mock<CTest> m = new Mock<CTest> { CallBase = true };
//            Mock<CTest> mockT = Mock.Get<CTest>(m.Object);
//            m.Setup(mtt => mtt.TestTest("koregahairuyotei")).Returns("yamada");
            m.Setup(mtt => mtt.TestTest("koregahairuyotei")).Returns("yamada");

            string actual = m.Object.Foo("koregahairuyotei");

            Assert.AreEqual("yamada", actual);
        }
    }
}
