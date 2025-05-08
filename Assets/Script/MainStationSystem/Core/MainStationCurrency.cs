using System.Collections.Generic;
using UnityEngine;

public class MainStationCurrency : IMainStationCurrency
{
    public Dictionary<string, int> CurrencyMap { get; private set; } = new Dictionary<string, int>
    {
        { "Gold", 0 },
        { "Diamond", 0 }
    };

    public void AddCurrency(string CurrencyType, int CurrencyCount)
    {
        if (!this.CurrencyMap.ContainsKey(CurrencyType))
            this.CurrencyMap[CurrencyType] = 0;

        this.CurrencyMap[CurrencyType] += CurrencyCount;

    }
    public void RemoveCurrency(string CurrencyType, int CurrencyCount)
    {
        if (!this.CurrencyMap.ContainsKey(CurrencyType)) return;
        if (this.CurrencyMap[CurrencyType] < CurrencyCount) return;
        this.CurrencyMap[CurrencyType] -= CurrencyCount;

    }


    public int GetCurrencyCount(string CurrencyType)
    {
        if (!this.CurrencyMap.ContainsKey(CurrencyType)) return 0;
        return this.CurrencyMap[CurrencyType];

    }


    public Dictionary<string, int> ExportAll() => new(this.CurrencyMap);
    public void LoadFrom(Dictionary<string, int> CurrencyTypeMap) => this.CurrencyMap = new(CurrencyTypeMap);


}