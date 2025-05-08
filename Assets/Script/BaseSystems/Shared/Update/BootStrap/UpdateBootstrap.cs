using UnityEngine;


public static class UpdateBootstrap
{
    public static void Initialize()
    {
        BaseBootstrap.AttachInstaller<UpdateInstaller>(false);
    }

}

