using System.Collections.Generic;

public class PlanetPointFactory : IPlanetPointFactory
{
    public IPlanetRespawner PlanetRespawner { get; private set; }
    public List<string> PlanetList { get; private set; }


    public void Create(PlanetPointCtrl ObjT)
    {
        this.PlanetRespawner = new PlanetRespawner(ObjT);
    }

  
    
       
    
}
