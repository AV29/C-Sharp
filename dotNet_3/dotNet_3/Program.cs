using System;
using System.Reflection;
using dotNet_3.Attributes;

namespace dotNet_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Track(new Tracked("Anton", "Vlasik"));
            Track(new UnTracked("Vladimirovich"));

            Console.ReadLine();
        }

        public static void Track(object obj)
        {
            var typeInfo = obj.GetType();
            if (typeInfo == null) {
                Console.WriteLine("There is no such type");
                Console.ReadLine();
                return;
            }
            var attributeInfo = typeInfo.GetCustomAttribute<TrackingEntityAttribute>();
            if (attributeInfo == null) return;

            Console.WriteLine(typeInfo);
            Console.WriteLine("-------------------------------------------");
            GetInfoAboutMembers(typeInfo);
        }

        private static void GetInfoAboutMembers(Type typeInfo)
        {
            const BindingFlags flags = BindingFlags.Public |
                                       BindingFlags.NonPublic |
                                       BindingFlags.Static |
                                       BindingFlags.Instance;

            foreach (var field in typeInfo.GetFields(flags))
            {
                var fieldInfo = field.GetCustomAttribute<TrackingPropertyAttribute>();
                if (fieldInfo == null) continue;
                string name = string.IsNullOrEmpty(fieldInfo.PropertyName) ? field.Name : fieldInfo.PropertyName;
                string value = field.Name;
                Console.WriteLine($"{name} = {value}");
            }

            foreach (var prop in typeInfo.GetProperties()) 
            {
                var propInfo = prop.GetCustomAttribute<TrackingPropertyAttribute>();
                if (propInfo == null) continue;
                string name = string.IsNullOrEmpty(propInfo.PropertyName) ? prop.Name : propInfo.PropertyName;
                string value = prop.Name;
                Console.WriteLine($"{name} = {value}");
            }
        }
    }
}
/*
    Задание 1. Создайте пользовательские атрибуты [TrackingEntity] и [TrackingProperty]. 
 Атрибут [TrackingEntity] можно однократно применить к пользовательскому классу или структуре. 
 Атрибут [TrackingProperty] можно однократно применить к полю или свойству. Также атрибут [TrackingProperty] содержит строковое свойство PropertyName.
 Создайте метод Track(), принимающим в качестве аргумента произвольный объект. 
 Если у объекта обнаруживается наличие атрибута [TrackingEntity], на консоль выводится имя типа объекта, 
 а также значения всех свойств и полей объекта, которые помечены атрибутом [TrackingProperty]. 

 Значения выводятся как пары «имя = значение», где «имя» – это та строка, 
 которая указана в PropertyName атрибута [TrackingProperty] (либо имя свойства/поля, если значение PropertyName равно null или пустой строке).
*/
