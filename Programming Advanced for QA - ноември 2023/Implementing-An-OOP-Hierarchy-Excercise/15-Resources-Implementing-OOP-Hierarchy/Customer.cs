using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy
{
    public class Customer
    {
        private List<Order> _orderHistory = new();

        public IReadOnlyCollection<Order> OrderHistory => _orderHistory.AsReadOnly();

        public Customer(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name {  get; set; }

        public string Email { get; set; }

        public void AddOrder(Order order)
        {
            this._orderHistory.Add(order);
        }
    }
}
