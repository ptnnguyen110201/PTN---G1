
public interface IPlanetFactory : IFactory<PlanetCtrl> 
{
    IPlanetStorage PlanetStorage { get;  }
    IPlanetResourceRestore PlanetResourceRestore { get; }
}