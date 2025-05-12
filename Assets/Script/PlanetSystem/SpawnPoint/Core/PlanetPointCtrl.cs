using System.Collections.Generic;
using UnityEngine;

public class PlanetPointCtrl : MonoBehaviour, IPoolable
{
    [Inject] public IPlanetManager PlanetManager;
    public IPlanetPointFactory PlanetFactory;

    public void OnDespawn()
    {
    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.PlanetFactory = new PlanetPointFactory();
        this.PlanetFactory.Create(this);
    }



}

