public class PlanetFactory : IPlanetFactory
{
    public IPlanetStorage PlanetStorage {  get; private set; }

    public IPlanetResourceRestore PlanetResourceRestore { get; private set; }


    public PlanetFactory() 
    {

    }
    public void Create(PlanetCtrl ObjT)
    {
        this.PlanetStorage = new PlanetStorage(this);
        this.PlanetResourceRestore = new PlanetResourceRestore(this, true);
    }
}