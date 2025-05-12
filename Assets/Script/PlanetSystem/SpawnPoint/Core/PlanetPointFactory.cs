using System.Collections.Generic;

public class PlanetPointFactory : IPlanetPointFactory
{
    public IPlanetRespawner PlanetRespawner { get; private set; }
    public List<string> PlanetList { get; private set; }

    public PlanetPointCtrl ObjT {  get; private set; }

    public void Create(PlanetPointCtrl ObjT)
    {
        this.ObjT = ObjT;
        this.PlanetRespawner = new PlanetRespawner(ObjT);
    }

    public void SetPlanetList(List<string> PlanetList) => this.PlanetList = new List<string>(PlanetList);
    
       
    
}
