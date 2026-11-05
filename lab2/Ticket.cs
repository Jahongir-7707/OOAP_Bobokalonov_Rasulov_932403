namespace CinemaTickets
{
    // Билет: право занять место на сеансе.
    public class Ticket
    {
        private double price;
        private string barcode;
        private Session session;   // -session [1]
        private Seat seat;         // -seat [1]

        public Ticket(Session session, Seat seat, double price)
        {
            this.session = session;
            this.seat = seat;
            this.price = price;
        }

        public double Price { get { return price; } }
        public string Barcode { get { return barcode; } }
        public Seat Seat { get { return seat; } }

        // Штрихкод формируется после оплаты: цифры даты сеанса, зал, ряд, место.
        public string GenerateBarcode()
        {
            string digits = "";
            foreach (char ch in session.DateTime)
                if (char.IsDigit(ch))
                    digits += ch;
            barcode = string.Format("{0}-{1}-{2}-{3}", digits, session.Hall.Number, seat.Row, seat.Number);
            return barcode;
        }

        public string GetInfo()
        {
            return string.Format("{0}, {1}, цена {2}", session.Film.GetInfo(), seat.GetLabel(), price);
        }
    }
}
