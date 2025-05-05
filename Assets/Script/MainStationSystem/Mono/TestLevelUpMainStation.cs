
using GameSystems.Shared.Interfaces.Installer;
using UnityEngine;

public class TestLevelUpMainStation : MonoBehaviour, IUpdatable
{
    [Inject] MainStation mainStation;

    public void OnUpdate(float deltaTime)
    {


    }

    protected void Start()
    {
        GameContext.Instance.Container.InjectInto(this);
        UpdateInstaller.Instance.Register(this);
    }

    
   
}


