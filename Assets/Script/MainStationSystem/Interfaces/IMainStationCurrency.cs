using System.Collections.Generic;

public interface IMainStationCurrency
{
    Dictionary<string, int> CurrencyMap { get; }
    void AddCurrency(string CurrencyType, int CurrencyCount);
    void RemoveCurrency(string CurrencyType, int CurrencyCount);
    int GetCurrencyCount(string CurrencyType);

}