public interface IPlanetFactory : IFactory<PlanetCtrl> 
{
    IPlanetStorage PlanetStorage { get; }
    IPlanetResourceRestore ResourceRestore { get; }
    IPlanetPickUp PlanetPickUp { get; }
}