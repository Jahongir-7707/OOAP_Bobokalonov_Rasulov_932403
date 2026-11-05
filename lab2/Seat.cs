namespace CinemaTickets
{
    // Абстрактное место. Доплата зависит от типа места и определяется в потомках.
    public abstract class Seat
    {
        protected int row;
        protected int number;

        protected Seat(int row, int number)
        {
            this.row = row;
            this.number = number;
        }

        public int Row { get { return row; } }
        public int Number { get { return number; } }

        public abstract double GetSurcharge();

        public string GetLabel()
        {
            return string.Format("ряд {0}, место {1}", row, number);
        }
    }

    // Обычное место: доплаты нет.
    public class StandardSeat : Seat
    {
        public StandardSeat(int row, int number) : base(row, number) { }

        public override double GetSurcharge()
        {
            return 0;
        }
    }

    // VIP-место: фиксированная доплата к цене билета.
    public class VipSeat : Seat
    {
        private double surcharge;

        public VipSeat(int row, int number, double surcharge) : base(row, number)
        {
            this.surcharge = surcharge;
        }

        public override double GetSurcharge()
        {
            return surcharge;
        }
    }
}
