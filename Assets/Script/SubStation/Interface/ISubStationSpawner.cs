using System.Threading.Tasks;
using UnityEngine;

public interface ISubStationSpawner : ISpawner<SubStationCtrl> 
{
    Task SpawnSubStation();

}