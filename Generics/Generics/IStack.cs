namespace Generics
{
    public interface IStack<T>
    {
        int Limit { get; }

        void Push(T el);

        bool IsEmpty();

        T Pop();
    }
}
