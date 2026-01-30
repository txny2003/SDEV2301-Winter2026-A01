using System.Transactions;

namespace CoffeeHouse
{
    public class Coffee
    {
        private bool _hasMilk;
        public double Price { get; }
        public string Size { get; }
        public string HasMilk
        {
            get
            {
                return _hasMilk ? "Yes" : "No";
            }
        }
        public string Roast { get; }

        public Coffee(double price, string size, bool hasMilk, string roast)
        {
            Price = price; 
            Size = size;
            _hasMilk = hasMilk;
            Roast = roast;
        }
    }
}
