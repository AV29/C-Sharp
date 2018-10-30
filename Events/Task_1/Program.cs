using System;
using static System.Console;

namespace Task_1
{
    class MainClass
    {

        public static void HandleMinChangedPrint(Object sender, MinChangedEventArgs e) 
        {
            WriteLine($"Min changed in '{sender}'; New min: {e.NewMin}");
        }

        public static void Main(string[] args)
        {
            var c = new Counter();
            c.Count(-10);
            c.MinChanged += HandleMinChangedPrint;
            c.MinChanged += HandleMinChangedPrint;
            c.MinChanged += HandleMinChangedPrint;
            c.MinChanged += HandleMinChangedPrint;
            c.Count(-20);
        }
    }
}

/*
Создайте класс Matrix<T> для преставления прямоугольной матрицы с элементами типа T. 
Опишите в классе событие ItemChanged, которое происходит после изменения элемента матрицы. 
Передавайте в обработчик события индексы элемента, старое и новое значение элемента.
*/
