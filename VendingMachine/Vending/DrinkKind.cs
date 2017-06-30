using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace TddbcCSharp.Vending
{
    public class DrinkKind
    {

        private string _name;
        private int _price;

        public DrinkKind(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public string Name
        {
            get { return this._name; }
        }

        public int Price
        {
            get { return _price; }
        }

        public static DrinkKind By(string drinkName)
        {
            return new DrinkKind(drinkName, 0);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is DrinkKind))
                return false;
            DrinkKind otherDrink = (DrinkKind)obj;
            return this.Name == otherDrink.Name;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
    }

}

