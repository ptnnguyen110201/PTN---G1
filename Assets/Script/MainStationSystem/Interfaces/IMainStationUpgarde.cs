public interface IMainStationUpgarde : IUpgrade
{
    IMainStationLevel MainStationLevel {  get; } 
    IMainStationStorage MainStationStorage { get; }



}