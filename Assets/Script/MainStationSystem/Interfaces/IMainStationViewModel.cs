using System.Collections.Generic;

public interface IMainStationViewModel
{
    int CurrentLevel { get; }
    int MaxLevel { get; }
    IReadOnlyDictionary<string, int> Resources { get; }

}
