using Overriding;

namespace Inheritance
{
    public class Rectangle : Figure
    {
        private int _width = 0;

        private int _height = 0;

        public int Width
        {
            get => _width;
            set
            {
                if (value < 0)
                {
                    _width = 0;
                }
                else
                {
                    _width = value;
                }
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (value < 0)
                {
                    _height = 0;
                }
                else
                {
                    _height = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Height = {Height}; Width = {Width}; Color = {FigureColor}; Square = {Aria()};";
        }

        public Rectangle() : this(Figure.DEFAULT_SIZE) { }

        public Rectangle(int size) : this(size, size) { }

        public Rectangle(int height, int width) : this(height, width, Figure.DEFAULT_COLOR) { }

        public Rectangle(int height, int width, Color color) : base(color)
        {
            Height = height;
            Width = width;
        }

        public override double Aria()
        {
            return Height * Width;
        }
    }
}
