using System.Collections.Generic;

namespace Checkout
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }

    public class Checkout : ICheckout
    {
        private readonly List<string> _items = new List<string>();
        public void Scan(string item)
        {
            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            var total = 0;
            foreach (var item in _items)
            {
                switch (item)
                {
                    case "A": 
                        total = 50;
                        break;
                    case "B": 
                        total = 30;
                        break;
                    case "C": 
                        total = 20;
                        break;
                    case "D":
                        total = 15;
                        break;
                }   
            }

            return total;
        }
    }
}