using UnityEngine;

public class MainStationCtrl : MonoBehaviour
{
     ILevel ILevel;


    private void Start()
    {
       
        Invoke(nameof(Test), 3f);
    }


    protected void Test() 
    {

        IMainStationLevel MainLevel = GameContext.Instance.Container.Resolve<IMainStationLevel>();
        this.ILevel = MainLevel;
        this.ILevel.OnLevelUp();
        Debug.Log(this.ILevel.CurrentLevel);
    }
}

