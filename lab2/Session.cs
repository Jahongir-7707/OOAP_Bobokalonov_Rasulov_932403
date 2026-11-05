using System;
using System.Collections.Generic;

namespace CinemaTickets
{
    // Сеанс: показ фильма в зале. Знает проданные на него билеты.
    public class Session
    {
        private string dateTime;
        private string format;
        private double basePrice;
        private Film film;                                   // -film [1]
        private Hall hall;                                   // -hall [1]
        private List<Ticket> tickets = new List<Ticket>();   // -tickets [0..*]

        public Session(string dateTime, string format, double basePrice, Film film, Hall hall)
        {
            this.dateTime = dateTime;
            this.format = format;
            this.basePrice = basePrice;
            this.film = film;
            this.hall = hall;
        }

        public string DateTime { get { return dateTime; } }
        public string Format { get { return format; } }
        public Film Film { get { return film; } }
        public Hall Hall { get { return hall; } }

        // Место свободно, если на него нет билета на этот сеанс.
        public bool IsSeatFree(Seat s)
        {
            foreach (Ticket t in tickets)
                if (t.Seat == s)
                    return false;
            return true;
        }

        // Цена = (базовая цена + доплата за место) * (1 - скидка).
        public double CalculatePrice(Seat s, double discount)
        {
            double surcharge = s.GetSurcharge();
            return Math.Round((basePrice + surcharge) * (1 - discount), 2);
        }

        public void RegisterTicket(Ticket t)
        {
            tickets.Add(t);
        }

        public void ReleaseTicket(Ticket t)
        {
            tickets.Remove(t);
        }
    }
}
