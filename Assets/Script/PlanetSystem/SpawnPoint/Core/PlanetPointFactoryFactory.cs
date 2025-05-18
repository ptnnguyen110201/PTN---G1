using System.Collections;
using System.Collections.Generic;

public class PlanetPointFactoryFactory : IPlanetPointFactoryFactory
{
    protected Stack<IPlanetPointFactory> IPlanetFactory = new Stack<IPlanetPointFactory>();
    public IPlanetPointFactory CreateFactory(PlanetPointCtrl planet)
    {
        IPlanetPointFactory planetPointFactory;
        if(this.IPlanetFactory.Count <= 0) planetPointFactory = new PlanetPointFactory();
        else planetPointFactory = this.IPlanetFactory.Pop();
        planetPointFactory.Create(planet);
        return planetPointFactory;
    }


    public void ReleaseFactory(IPlanetPointFactory planetPointFactory)
    {
        planetPointFactory.Destroy();
        this.IPlanetFactory.Push(planetPointFactory);
    }
}

