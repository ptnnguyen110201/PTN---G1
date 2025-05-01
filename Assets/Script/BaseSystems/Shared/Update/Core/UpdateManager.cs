using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : IUpdateManager
{
    private readonly List<IUpdatable> updates = new();
    private readonly List<ILateUpdatable> lateUpdates = new();
    private readonly List<IFixedUpdatable> fixedUpdates = new();
    public void Register(IUpdatable obj) => this.AddUnique(obj, this.updates);
    public void Unregister(IUpdatable obj) => this.updates.Remove(obj);

    public void Register(ILateUpdatable obj) => this.AddUnique(obj, this.lateUpdates);
    public void Unregister(ILateUpdatable obj) => this.lateUpdates.Remove(obj);

    public void Register(IFixedUpdatable obj) => this.AddUnique(obj, this.fixedUpdates);
    public void Unregister(IFixedUpdatable obj) => this.fixedUpdates.Remove(obj);

    protected void AddUnique<T>(T obj, List<T> list)
    {
        if (!list.Contains(obj)) list.Add(obj);
    }

    public void Update()
    {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < this.updates.Count; i++)
            this.updates[i].OnUpdate(deltaTime);
    }

    public void LateUpdate()
    {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < this.lateUpdates.Count; i++)
            this.lateUpdates[i].OnLateUpdate(deltaTime);
    }

    public void FixedUpdate()
    {
        float fixedDeltaTime = Time.fixedDeltaTime;
        for (int i = 0; i < this.fixedUpdates.Count; i++)
            this.fixedUpdates[i].OnFixedUpdate(fixedDeltaTime);
    }



    public void Initialize()
    {
        return;
    }
}
