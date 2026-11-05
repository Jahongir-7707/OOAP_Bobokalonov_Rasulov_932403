using System.Collections.Generic;

namespace CinemaTickets
{
    // Заказ. Композиция с Ticket: билеты существуют только в составе заказа.
    public class Order
    {
        private static int maxTickets = 8;   // статический атрибут

        private int number;
        private string date;
        private double total;
        private string status;
        private string tariff;
        private double discount;
        private Session session;                             // -session [1]
        private List<Ticket> tickets = new List<Ticket>();   // -tickets [1..*]
        private IPaymentMethod paymentMethod;                // -paymentMethod [0..1]

        public Order(int number, Session session, string tariff, double discount)
        {
            this.number = number;
            this.session = session;
            this.tariff = tariff;
            this.discount = discount;
            this.date = System.DateTime.Now.ToString("dd.MM.yyyy");
            this.total = 0;
            this.status = "оформлен";
        }

        public int Number { get { return number; } }
        public double Total { get { return total; } }
        public string Date { get { return date; } }
        public string Status { get { return status; } }
        public string Tariff { get { return tariff; } }
        public IPaymentMethod PaymentMethod { get { return paymentMethod; } }
        public IList<Ticket> Tickets { get { return tickets.AsReadOnly(); } }

        // Добавляет билет на место s, если место свободно и лимит не превышен.
        public bool AddTicket(Seat s)
        {
            bool result = false;
            bool free = session.IsSeatFree(s);
            if (free && tickets.Count < maxTickets)
            {
                double price = session.CalculatePrice(s, discount);
                Ticket t = new Ticket(session, s, price);
                session.RegisterTicket(t);
                tickets.Add(t);
                RecalculateTotal(price);
                result = true;
            }
            return result;
        }

        private void RecalculateTotal(double price)
        {
            total += price;
        }

        // Оплата заказа выбранным способом; после успеха формируются штрихкоды.
        public bool Pay(IPaymentMethod m)
        {
            bool ok = m.Pay(total);
            if (ok)
            {
                paymentMethod = m;
                status = "оплачен";
                foreach (Ticket t in tickets)
                    t.GenerateBarcode();
            }
            return ok;
        }

        // Отмена: билеты аннулируются, места освобождаются.
        public void Cancel()
        {
            foreach (Ticket t in tickets)
                session.ReleaseTicket(t);
            tickets.Clear();
            total = 0;
            status = "отменён";
        }
    }
}
