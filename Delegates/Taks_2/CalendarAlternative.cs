using System;
namespace Taks_2
{
    public class CalendarAlternative
    {
        public Season Season { get; }

        public Locale Locale { get; }

        public Func<Season, string> Localizator { get; }

        public CalendarAlternative(Season season, Func<Season, string> localizator = null) 
        {
            Season = season;
            Localizator = localizator;
        }

        public override string ToString()
        {
            return Localizator == null ? Season.ToString() : Localizator(Season);
        }
    }
}
