using UnityEngine;


public static class UpdateBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        BaseBootstrap.AttachInstaller<UpdateInstaller>(true);
    }

}

