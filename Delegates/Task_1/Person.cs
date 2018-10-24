using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            return (Age.ToString() + Name).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            return p.Age == Age && p.Name == Name;
        }

        public override string ToString()
        {
            return $"{Name}:{Age}";
        }
    }
}
