using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{

    [SerializeField] Button _hub;

    // Start is called before the first frame update
    void Start()
    {
        _hub.onClick.AddListener(LoadHub);
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
    private void LoadHub()
    {
        ScenesManager.Instance.LoadHub();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
