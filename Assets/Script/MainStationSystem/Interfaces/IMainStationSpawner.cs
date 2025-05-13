using System.Threading.Tasks;

public interface IMainStationSpawner : ISpawner<MainStationCtrl>
{

    Task SpawnMainStation();
}