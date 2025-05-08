using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneBootstrapper : MonoBehaviour
{
    protected IBootstrapper bootstrapper;

    protected void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "MainMenu":
                bootstrapper = new MainMenuBootstrapper();

                break;
            default:
                Debug.LogWarning($"No bootstrapper found for scene {sceneName}");
                break;
        }

        this.bootstrapper?.Initialize();

    }




}

