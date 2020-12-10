using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenService.Api.Model
{
    public class Fridge: Appliance
    {

        private readonly ISet<FridgeItem> _items;

        public IReadOnlySet<FridgeItem> Contents => new HashSet<FridgeItem>(_items);

        public Fridge()
        {
            _items.Add(new() { ID = 1, Name = "Energy Drink", WeightOz = 12, Expiration = new DateTime(2021, 1, 10)});
            _items.Add(new() { ID = 1, Name = "Ham", WeightOz = 10, Expiration = new DateTime(2021, 12, 1) });
            _items.Add(new() { ID = 1, Name = "Eggs", WeightOz = 12, Expiration = new DateTime(2021, 1, 10) });

        }

        public bool AddItem(FridgeItem item)
        {
            if (_items.Any(x => x.ID == item.ID))
            {
                return false;
            }

            _items.Add(item);
            return true;
        }


        public ISet<FridgeItem> Clean()
        {
            var expired = _items.Where(x => x.isExpired).ToHashSet();
            _items.ExceptWith(expired);
            return expired.ToHashSet();
        }


    }
}
