namespace Taks_2
{
    public class Calendar
    {
        public Season Season { get; }

        public Locale Locale { get; }

        public Localizator Localizator { get; }

        public Calendar(Season season, Locale locale = Locale.En, Localizator localizator = null)
        {
            Season = season;
            Locale = locale;
            Localizator = localizator;
        }

        public override string ToString()
        {
            return Localizator == null ? Season.ToString() : Localizator(Season, Locale);
        }
    }
}
