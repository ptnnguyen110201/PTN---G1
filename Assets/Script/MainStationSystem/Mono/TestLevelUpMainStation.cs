using GameSystems.Shared.Interfaces.Installer;
using UnityEngine;

public class TestLevelUpMainStation : MonoBehaviour , IUpdatable
{
    public int Level;
    public int MaxLevel;
    public int CurrentResources;
    public int RequiredResources;
    protected void Start()
    {
        UpdateInstaller.Instance.Register(this);
        InvokeRepeating(nameof(this.TestLevelUp), 1f, 1f);
    }
    public void OnUpdate(float deltaTime)
    {
        this.Test();
    }
    protected void TestLevelUp() 
    {
        MainStationInstaller.Instance.MainStationLevel.AddResources(1);
    }
    protected void Test() 
    {
        this.Level = MainStationInstaller.Instance.MainStationLevel.CurrentLevel;
        this.MaxLevel = MainStationInstaller.Instance.MainStationLevel.MaxLevel;
        this.CurrentResources = MainStationInstaller.Instance.MainStationLevel.CurrentResources;
        this.RequiredResources = MainStationInstaller.Instance.MainStationLevel.RequiredResources;
    }
}