namespace CinemaTickets
{
    public class Film
    {
        private string title;
        private string genre;
        private int duration;   // минуты
        private int ageRating;  // 0, 6, 12, 16, 18

        public Film(string title, string genre, int duration, int ageRating)
        {
            this.title = title;
            this.genre = genre;
            this.duration = duration;
            this.ageRating = ageRating;
        }

        public string GetInfo()
        {
            return string.Format("{0} ({1}, {2} мин, {3}+)", title, genre, duration, ageRating);
        }
    }
}
