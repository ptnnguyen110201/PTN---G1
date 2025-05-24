using UnityEngine;

public class SaveManagerCtrl : MonoBehaviour 
{
    [Inject] ISaveManager SaveManager;


    protected async void Start()
    {
        GameContext.Instance.Container.InjectInto(this);
        await this.SaveManager.Initialize();
    }

    protected void OnApplicationQuit()
    {
        this.SaveManager.Save();
    }
    protected void OnApplicationPause(bool pause)
    {
        if(pause) this.SaveManager.Save();
    }
}