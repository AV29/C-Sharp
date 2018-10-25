using System;
namespace Taks_2
{
    public delegate string Localizator(Season season);

    public class Localization
    {
        public static string En(Season season)
        {
            return season.ToString();
        }

        public static string Es(Season season)
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

        public static string Ru(Season season)
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
