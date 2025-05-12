using UnityEngine;

public class MainStationCtrl : MonoBehaviour
{
   
    [Inject] public IMainStation MainStation;



    private void Start()
    {
      
        GameContext.Instance.Container.InjectInto(this);
    }
}

