namespace CinemaTickets
{
    // Способ оплаты. Разные способы реализуют один контракт.
    public interface IPaymentMethod
    {
        bool Pay(double amount);
        string GetName();
    }

    public class CardPayment : IPaymentMethod
    {
        private string cardMask;

        public CardPayment(string cardMask)
        {
            this.cardMask = cardMask;
        }

        // Учебная заглушка: обращение к платёжному сервису не реализуется.
        public bool Pay(double amount)
        {
            return amount > 0;
        }

        public string GetName()
        {
            return "Банковская карта " + cardMask;
        }
    }

    public class SbpPayment : IPaymentMethod
    {
        private string phone;

        public SbpPayment(string phone)
        {
            this.phone = phone;
        }

        public bool Pay(double amount)
        {
            return amount > 0;
        }

        public string GetName()
        {
            return "СБП, телефон " + phone;
        }
    }
}
