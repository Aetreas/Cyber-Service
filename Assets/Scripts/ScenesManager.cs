using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        SampleScene,
        Tutorial,
        Level1,
        Level3,
        HowToPlay
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene(Scene.Tutorial.ToString());
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(Scene.Level1.ToString());
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(Scene.Level3.ToString());
    }
    public void LoadHub()
    {
        SceneManager.LoadScene(Scene.SampleScene.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene(Scene.HowToPlay.ToString());
    }

}
