using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    [SerializeField] Button _hub;
    [SerializeField] Button _mainmenu;
    [SerializeField] Button _levelone;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        _hub.onClick.AddListener(LoadHub);
        _mainmenu.onClick.AddListener(LoadMainMenu);
        _levelone.onClick.AddListener(LoadLevel1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //   public void PauseGame()
    //   {
    //      levelSelect.SetActive(true);
    //      Time.timeScale = 0f;
    //     isPaused = true;
    //     Cursor.lockState = CursorLockMode.None;
    //  }

    //  public void ResumeGame()
    //  {
    //     levelSelect.SetActive(false);
    //     Time.timeScale = 1f;
    //     isPaused = false;
    //     Cursor.lockState = CursorLockMode.Locked;
    // }

    public void GameOverMenu()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    private void LoadLevel1()
    {
        ScenesManager.Instance.LoadLevel1();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    private void LoadHub()
    {
        ScenesManager.Instance.LoadHub();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    private void LoadMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}
