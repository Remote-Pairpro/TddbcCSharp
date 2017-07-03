using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace TddbcCSharp.Vending
{
    public class DrinkKind
    {
        public DrinkKind(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public int Price { get; }

        public static DrinkKind By(string drinkName)
        {
            return new DrinkKind(drinkName, 0);
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is DrinkKind))
                return false;
            var otherDrink = (DrinkKind)obj;
            return Name == otherDrink.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

}

