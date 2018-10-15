using System;
using Overriding;

namespace Inheritance
{
    public class Circle : Figure
    {
        private int _radius = 0;

        public int Radius {
            get => _radius;
            set {
                if (value < 0)
                {
                    _radius = 0;
                } else {
                    _radius = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Radius = {Radius}; Color = {FigureColor}; Square = {Aria()};";
        }

        public Circle() : this(Figure.DEFAULT_SIZE) { }

        public Circle(int radius) : this(radius, Figure.DEFAULT_COLOR) { }

        public Circle(int radius, Color color) : base(color)
        {
            Radius = radius;
        }

        public override double Aria()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
