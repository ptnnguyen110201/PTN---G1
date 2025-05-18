using System.Collections.Generic;
using UnityEngine;

public class PlanetPointCtrl : MonoBehaviour, IPoolable
{
    [Inject] public IPlanetManager PlanetManager;
    [Inject] public IPlanetPointFactoryFactory PlanetPointFactoryFactory;
    public IPlanetPointFactory PlanetPointFactory { get; protected set; }

    public List<string> PlanetList { get; private set; }
    public void SetPlanetList(List<string> PlanetList) => this.PlanetList = new(PlanetList);
    public void OnDespawn()
    {
    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.PlanetPointFactory = this.PlanetPointFactoryFactory.CreateFactory(this);



    }



}

