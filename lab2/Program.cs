using System;

namespace CinemaTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Hall hall = new Hall(2, "стандартный");
            for (int row = 1; row <= 5; row++)
                for (int n = 1; n <= 14; n++)
                    if (row == 5 && n > 12)
                        hall.AddSeat(new VipSeat(row, n, 200));
                    else
                        hall.AddSeat(new StandardSeat(row, n));

            Film film = new Film("Интерстеллар", "фантастика", 169, 12);
            Session session = new Session("2026-11-07 19:30", "2D", 400, film, hall);
            Customer ivan = new Customer("Иван Петров", "+7 913 000-00-00", "ivan@mail.ru");

            BookingService service = new BookingService();
            Seat[] chosen = { hall.GetSeat(5, 12), hall.GetSeat(5, 13) };
            Order order = service.CreateOrder(ivan, session, chosen, "студенческий");
            Console.WriteLine("Заказ {0}: {1} билета, сумма {2}, статус {3}",
                order.Number, order.Tickets.Count, order.Total, order.Status);

            // Повторная попытка купить уже занятое место
            Order second = service.CreateOrder(ivan, session, new Seat[] { hall.GetSeat(5, 12) }, "взрослый");
            Console.WriteLine("Заказ {0}: {1} билетов (место занято)", second.Number, second.Tickets.Count);

            bool ok = order.Pay(new CardPayment("**** 4417"));
            Console.WriteLine("Оплата: {0}, статус {1}", ok, order.Status);
            foreach (Ticket t in order.Tickets)
                Console.WriteLine("  {0} | штрихкод {1}", t.GetInfo(), t.Barcode);
            Console.WriteLine("Заказов в истории: {0}", ivan.GetOrderHistory().Length);
        }
    }
}
