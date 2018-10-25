using System;
namespace Taks_2
{
    public class Calendar
    {
        public Season Season { get; }

        public Localizator Localizator { get; }

        public Calendar(Season season, Localizator localizator = null) 
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
