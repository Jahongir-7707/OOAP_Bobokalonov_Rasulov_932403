namespace CinemaTickets
{
    // Сервис продажи билетов (контроллер сценария оформления заказа).
    public class BookingService
    {
        private int orderCounter = 1023;

        public Order CreateOrder(Customer c, Session s, Seat[] seats, string tariff)
        {
            double discount = GetDiscount(tariff);
            orderCounter++;
            Order order = new Order(orderCounter, s, tariff, discount);
            foreach (Seat seat in seats)
                order.AddTicket(seat);
            c.AddOrder(order);
            return order;
        }

        private double GetDiscount(string tariff)
        {
            switch (tariff)
            {
                case "детский": return 0.5;
                case "студенческий": return 0.2;
                default: return 0;
            }
        }
    }
}
