using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T02.Composite
{
    internal class CompositeGift : GiftBase, IGiftOperations
    {
        List<GiftBase> _gifts;
        public CompositeGift(string name, int price)
            : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this._gifts.Add(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;
            Console.WriteLine($"{name} contains the following products with prices:");
            foreach (var gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }
            return total;
        }

        public void Remove(GiftBase gift)
        {
            this._gifts.Remove(gift);

        }
    }
}
