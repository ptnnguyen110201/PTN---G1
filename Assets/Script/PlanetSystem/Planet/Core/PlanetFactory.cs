public class PlanetFactory : IPlanetFactory
{    
    public IPlanetStorage PlanetStorage {  get; private set; }
    public IPlanetResourceRestore ResourceRestore { get; private set; }
    public IPlanetPickUp PlanetPickUp { get; private set; }
    public PlanetCtrl ObjT {  get; private set; }

    public void Create(PlanetCtrl ObjT)
    {
        this.ObjT = ObjT;
        this.PlanetStorage = new PlanetStorage(this);
        this.ResourceRestore = new PlanetResourceRestore(this, true);
        this.PlanetPickUp = new PlanetPickUp(this);

    }
}