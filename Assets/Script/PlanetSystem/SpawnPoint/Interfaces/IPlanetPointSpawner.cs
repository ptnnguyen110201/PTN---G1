using System.Threading.Tasks;

public interface IPlanetPointSpawner : ISpawner<PlanetPointCtrl> 
{
    Task SpawnPlanetPoint();
}