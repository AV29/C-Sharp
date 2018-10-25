namespace Generics
{
    public static class StackExtension
    {
        public static Stack<T> Reverse<T>(this IStack<T> stack)
        {
            Stack<T> newStack = new Stack<T>(stack.Limit);
            Stack<T> temp = new Stack<T>(stack.Limit);
            while (!stack.IsEmpty()) {
                T item = stack.Pop();
                temp.Push(item);
                newStack.Push(item);
            }
            while(!temp.IsEmpty())
            {
                stack.Push(temp.Pop());
            }
            return newStack;
        }
    }
}
