using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    [SerializeField] Button _mainMenu;
    [SerializeField] Button _quitGame;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        _mainMenu.onClick.AddListener(LoadMainMenu);
        _quitGame.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LoadMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
        Time.timeScale = 1f;
    }

    private void QuitGame()
    {
        ScenesManager.Instance.QuitGame();
    }
}
