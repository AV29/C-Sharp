namespace Generics
{
    public static class StackExtension
    {
        public static Stack<T> Reverse<T>(this IStack<T> stack)
        {
            Stack<T> newStack = new Stack<T>(stack.Limit);
            while (!stack.IsEmpty()) newStack.Push(stack.Pop());
            return newStack;
        }
    }
}
