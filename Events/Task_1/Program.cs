using System;
using static System.Console;

namespace Task_1
{
    class MainClass
    {

        public static void Print(Object sender, MinChangedEventArgs e) 
        {
            WriteLine();
        }

        public static void Main(string[] args)
        {
            var c = new Counter();
            c.Count(-10);
            c.MinChanged += Print;
            c.Count(-20);
            ReadLine();
        }
    }
}

/*
Модифицируйте класс Counter, показанный в презентации №12, 
чтобы с событием MinChanged в объекте этого класса нельзя было связать более трёх обработчиков. 
Продемонстрируйте работу с событием на примерах.


Создайте класс Matrix<T> для преставления прямоугольной матрицы с элементами типа T. 
Опишите в классе событие ItemChanged, которое происходит после изменения элемента матрицы. 
Передавайте в обработчик события индексы элемента, старое и новое значение элемента.
*/
