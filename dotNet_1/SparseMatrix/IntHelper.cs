namespace SparseMatrixSpace
{
    public static class IntHelper
    {
        public static bool IsPrime(this int number) {
            int start = number;
            int divisor = 2;
            while (number > 1)
            {
                if (number % divisor == 0)
                {
                    number /= divisor;
                    divisor--;
                }
                divisor++;
            }
            return divisor == start;
        }
    }
}
