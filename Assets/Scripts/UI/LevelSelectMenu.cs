using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public GameObject levelSelect;
    public bool isPaused;

    [SerializeField] Button _levelone;
    [SerializeField] Button _levelthree;

    // Start is called before the first frame update
    void Start()
    {
        levelSelect.SetActive(false);
        _levelone.onClick.AddListener(LoadLevel1);
        _levelthree.onClick.AddListener(LoadLevel3);
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
    private void LoadLevel1()
    {
        ScenesManager.Instance.LoadLevel1();
    }
    private void LoadLevel3()
    {
        ScenesManager.Instance.LoadLevel3();
    }
}
