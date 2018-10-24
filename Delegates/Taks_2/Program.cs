using System;

namespace Taks_2
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Localizator localizator = new Localizator(Localization.GetLocalName);


            Console.WriteLine(new Calendar(Season.Fall));

            Console.WriteLine(new Calendar(Season.Fall, Locale.Ru, localizator));

            Console.WriteLine(new Calendar(Season.Fall, Locale.Es, localizator));

            Console.WriteLine("---------------------- Alternative ----------------------");

            Localization l = new Localization();


            Console.WriteLine(new CalendarAlternative(Season.Spring));

            Console.WriteLine(new CalendarAlternative(Season.Spring, l.Localizator(Locale.Ru)));

            Console.WriteLine(new CalendarAlternative(Season.Spring, l.Localizator(Locale.Es)));

        }
    }
}

/*
Объект класса Calendar хранит одно из значений перечисления Season (времена года). 
Кроме этого, объект класса Calendar может хранит экземпляр делегата Localizator.
Этот делегат описывает способ получения по значению перечисления некой строки 
(предполагается, что это будет название сезона на определённом языке – английском, русском,…). 
Метод ToString() класса Calendar должен использовать в своей работе экземпляр делегата Localizator 
(предусмотреть, что этот экземпляр может быть равен null).
*/
