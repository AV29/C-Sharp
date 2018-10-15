using Overriding;

namespace Inheritance
{
    public abstract class Figure
    {
        public static readonly int DEFAULT_SIZE = 0;

        public static readonly Color DEFAULT_COLOR = new Color(255, 255, 255);

        public Color FigureColor { get; set;  }

        public Figure(Color color)
        {
            FigureColor = color;
        }

        public abstract double Aria();
    }
}
