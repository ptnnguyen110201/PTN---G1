public interface IFactory<T>
{
    void Create(T ObjT);
    void Destroy();   
}
