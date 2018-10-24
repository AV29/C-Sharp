using System;
namespace Taks_2
{
    public delegate string Localizator(Season season, Locale language);

    public class Localization
    {
        public static string GetLocalName(Season season, Locale locale) 
        {
            switch (locale)
            {
                case Locale.Ru:
                    {
                        return RuLocalizator(season);
                    }
                case Locale.Es:
                    {
                        return EsLocalizator(season);
                    }
                case Locale.En:
                    {
                        return EnLocalizator(season);
                    }
                default:
                    return EnLocalizator(season);
            }
        }

        public Func<Season, string> Localizator(Locale locale)
        {
            switch (locale)
            {
                case Locale.Ru:
                    {
                        return RuLocalizator;
                    }
                case Locale.Es:
                    {
                        return EsLocalizator;
                    }
                case Locale.En:
                    {
                        return EnLocalizator;
                    }
                default:
                    return EnLocalizator;
            }
        }

        public static string EnLocalizator(Season season)
        {
            return season.ToString();
        }

        public static string EsLocalizator(Season season)
        {
            switch (season)
            {
                case Season.Spring:
                    {
                        return "Primavera";
                    }
                case Season.Summer:
                    {
                        return "Verano";
                    }
                case Season.Fall:
                    {
                        return "Otoño";
                    }
                case Season.Winter:
                    {
                        return "Invierno";
                    }
                default: return season.ToString();
            }
        }

        public static string RuLocalizator(Season season)
        {
            switch (season)
            {
                case Season.Spring:
                    {
                        return "Весна";
                    }
                case Season.Summer:
                    {
                        return "Лето";
                    }
                case Season.Fall:
                    {
                        return "Осень";
                    }
                case Season.Winter:
                    {
                        return "Зима";
                    }
                default: return season.ToString();
            }
        }
    }
}
