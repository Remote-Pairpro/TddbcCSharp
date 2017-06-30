using System.Collections.Generic;
using static VendingMachine.Vending.JapaneseMoney;

namespace VendingMachine.Vending
{
    public enum JapaneseMoney
    {
        一円玉 = 1,
        五円玉 = 5,
        十円玉 = 10,
        五十円玉 = 50,
        百円玉 = 100,
        五百円玉 = 500,
        千円札 = 1000,
        五千円札 = 5000,
        一万円札 = 10000
    }

    public static class JapaneseMoneySupport
    {
        private static readonly List<JapaneseMoney> VALID_MOENY = new List<JapaneseMoney> {
            十円玉,
            五十円玉,
            百円玉,
            五百円玉,
            千円札
        };

        public static bool CanUse(this JapaneseMoney money)
        {
            return VALID_MOENY.Contains(money);
        }

    }

}
