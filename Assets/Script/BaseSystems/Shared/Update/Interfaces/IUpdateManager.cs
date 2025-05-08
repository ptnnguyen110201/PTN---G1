
public interface IUpdateManager : IInitializableSystem
{
    void Update();
    void FixedUpdate();
    void LateUpdate();
    void Register(IUpdatable obj);
    void Unregister(IUpdatable obj);
    void Register(ILateUpdatable obj);
    void Unregister(ILateUpdatable obj);
    void Register(IFixedUpdatable obj);
    void Unregister(IFixedUpdatable obj);


}
