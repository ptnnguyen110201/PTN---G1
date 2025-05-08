using System.Collections.Generic;

public class MainStationViewModel : IMainStationViewModel
{

    [Inject] readonly IMainStation MainStation;

    public MainStationViewModel(IMainStation mainStation)
    {
        this.MainStation = mainStation;
    }

    public int CurrentLevel => this.MainStation.MainStationLevel.CurrentLevel;
    public int MaxLevel => this.MainStation.MainStationLevel.MaxLevel;

    public IReadOnlyDictionary<string, int> Resources => this.MainStation.MainStationStorage.ExportAll();
}
