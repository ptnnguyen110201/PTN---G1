using System.Collections.Generic;
using UnityEngine;

public class PlanetPointCtrl : MonoBehaviour, IPoolable
{
    [Inject] public IPlanetManager PlanetManager;
    public IPlanetPointFactory PlanetPointFactory { get; protected set; }


   
    public void OnDespawn()
    {
    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.PlanetPointFactory = new PlanetPointFactory();
        this.PlanetPointFactory.Create(this);

     
    }



}

