namespace Overriding
{
    public class Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public override bool Equals(object obj)
        {
            Color color = (Color)obj;
            if (obj == null)
            {
                return false;
            }

            return color.R == R && color.G == G && color.B == B;
        }

        public override int GetHashCode()
        {
            return (R + G + B).GetHashCode();
        }

        public override string ToString()
        {
            if (R == 255 && G == 255 && B == 255) return "White";
            if (R == 255 && G == 0 && B == 0) return "Red";
            if (R == 0 && G == 255 && B == 0) return "Green";
            if (R == 0 && G == 0 && B == 255) return "Blue";
            if (R == 0 && G == 0 && B == 0) return "Black";
            
            return $"R: {R}, G: {G}, B: {B}";
        }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
