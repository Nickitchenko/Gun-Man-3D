using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public GameObject light; //fixe bug with light by second push level

    public SceneFader sceneFader;

    public void Start()
    {
        Time.timeScale = 1f;
        light.GetComponent<Light>().intensity = 2;
    }

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
