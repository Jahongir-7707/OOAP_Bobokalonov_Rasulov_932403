using System.Collections.Generic;

namespace CinemaTickets
{
    // Зал. Композиция с Seat: зал создаёт свои места и владеет ими.
    public class Hall
    {
        private int number;
        private string type;
        private List<Seat> seats = new List<Seat>(); // -seats [1..*]

        public Hall(int number, string type)
        {
            this.number = number;
            this.type = type;
        }

        public int Number { get { return number; } }
        public string Type { get { return type; } }

        // Добавляет место в зал; далее зал владеет местом (композиция).
        public void AddSeat(Seat s)
        {
            seats.Add(s);
        }

        public Seat GetSeat(int row, int number)
        {
            foreach (Seat s in seats)
                if (s.Row == row && s.Number == number)
                    return s;
            return null;
        }

        public int GetCapacity()
        {
            return seats.Count;
        }
    }
}
