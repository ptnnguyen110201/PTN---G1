
using GameSystems.Shared.SystemBase;

public interface IMainStation : IInitializableSystem
{
    public IMainStationLevel MainStationLevel { get; }    

}
