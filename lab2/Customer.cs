using System.Collections.Generic;

namespace CinemaTickets
{
    // Покупатель. Агрегация с Order: история заказов хранится и после удаления профиля.
    public class Customer
    {
        private string name;
        private string phone;
        private string email;
        private List<Order> orders = new List<Order>();   // -orders [0..*]

        public Customer(string name, string phone, string email)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
        }

        public string Name { get { return name; } }

        public void AddOrder(Order o)
        {
            orders.Add(o);
        }

        public Order[] GetOrderHistory()
        {
            return orders.ToArray();
        }
    }
}
