using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy
{
    public class Order
    {
        private List<MenuItem> _items = new();

        // Create IReadOnlyCollection
        public IReadOnlyCollection<MenuItem> Items => this._items.AsReadOnly();


        // Create new method
        public void AddItem(MenuItem item)
        {
            this._items.Add(item);
        }

        public decimal GetTotal()
        {
            // Sum of all prices within the order
            return this._items.Select(x => x.Price).Sum();
        }

    }
}
