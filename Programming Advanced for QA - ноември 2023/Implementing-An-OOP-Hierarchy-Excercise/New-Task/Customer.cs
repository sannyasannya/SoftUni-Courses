using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy
{
    public class Customer
    {
        // Create list of orders as a private field
        private List<Order> _orderHistory = new();

        // Create IReadOnlyCollection
        public IReadOnlyCollection<Order> OrderHistory => this._orderHistory.AsReadOnly();

        // Create public properties
        public string Name { get; set; }
        public string Email { get; set; }

        // Create constructor 

        public Customer(string name, string email) 
        {
            this.Name = name;
            this.Email = email;
        }

        // Create a new method AddOrder(Order order) – adds the given order to the _orderHistory list

        public void AddOrder(Order order)
        {
            this._orderHistory.Add(order);
        }
    }
}
