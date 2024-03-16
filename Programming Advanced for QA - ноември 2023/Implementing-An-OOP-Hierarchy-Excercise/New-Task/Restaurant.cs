using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy
{
    public class Restaurant
    {
        // Create lists as a private field
        private List<Customer> _customers = new();
        private List <MenuItem> _menu = new();

        //Create Method AddCustomer(Customer customer) – adds the given customer to the _customers list.
        public void AddCustomer(Customer customer)
        {
            this._customers.Add(customer);
        }

        // Create Method GetMenuItem(int index) – returns the menu item at the given index.
            // Check if the index is in bounds! If not throw an IndexOutOfRangeException.

        public MenuItem GetMenuItem(int index)
        {
            if (index < _menu.Count)
            {
                return this._menu[index];
            }
            else
                throw new IndexOutOfRangeException();
        }

        // Create Method AddMenuItem(MenuItem item) – adds the given menu item to the _menu list.
        public void AddMenuItem(MenuItem item) 
        {
            _menu.Add(item);
        }

        // Create Method PlaceOrder(Customer customer, Order order) – 
        //adds the given order to the customers _orderHistory list through the method we wrote.

        public void PlaceOrder(Customer customer, Order order)
        {
            customer.AddOrder(order);
        }

        //Method DisplayMenu() – First write to the console 
        //"Menu Items:" then foreach menu item in _menu write the item to the console.

        public void DisplayMenu()
        {
            Console.WriteLine("Menu Items:");
            foreach (MenuItem item in _menu)
            {
                Console.WriteLine(item.ToString());
            }        

        }
        
        // Method DisplayOrderHistory(Customer customer) 1. Write to the console "{customer.Name}'s Order History:".
        public void DisplayOrderHistory(Customer customer, Order order)
        {
            Console.WriteLine($"{customer.Name}'s Order History:");
            NewMethod(customer); ;

            //Finally foreach item in the orders items write to the console on each line "  {item}".
            foreach (MenuItem item in order.Items)
            {
                Console.WriteLine($"{item}");
            }

            static void NewMethod(Customer customer)
            {
                //2.Foreach order in the customers read only order collection write to the console "Order Total: ${order.GetTotal()}".
                foreach (var order in customer.OrderHistory)
                {
                    Console.WriteLine($"Order Total: ${order.GetTotal()}");
                }
            }
        }

    }
}
