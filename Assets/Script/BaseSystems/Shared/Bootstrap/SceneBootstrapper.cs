using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneBootstrapper : MonoBehaviour
{
    protected IBootstrapper bootstrapper;
    protected async void Awake()
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

        await this.bootstrapper?.Initialize();
    }




}

