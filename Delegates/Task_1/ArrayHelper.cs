using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public static class ArrayHelper
    {
        public static T[] Filter<T>(this T[] arr, Func<T, bool> predicate)
        {
            if (arr.Length == 0) return new T[arr.Length];

            T[] tempResult = new T[arr.Length];
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (predicate(arr[i]))
                {
                    tempResult[counter] = arr[i];
                    counter++;
                }
            }
            T[] finalResult = new T[counter];
            for (int i = 0; i < counter; i++)
            {
                finalResult[i] = tempResult[i];
            }
            tempResult = null;
            return finalResult;
        }

        public static bool Some<T>(this T[] arr, Func<T, bool> predicate)
        {
            int i = 0;
            while(i < arr.Length)
            {
                if (predicate(arr[i])) return true;
                i++;
            }
            return false;
        }

        public static string ArrayOutput<T>(this T[] array)
        {
            StringBuilder result = new StringBuilder();
            if (array.Length == 0)
            {
                result.Append("no result!");
            }
            else
            {
                for (var i = 0; i < array.Length; i++)
                {
                    result.Append($"{array[i]} ");
                }
            }
            return result.ToString();
        }
    }
}