public interface IFactory<T>
{
    T ObjT { get; }
    void Create(T ObjT);
}
