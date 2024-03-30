using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{
    [SerializeField] Button _mainmenu;

    // Start is called before the first frame update
    void Start()
    {
        _mainmenu.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    private void MainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
        Debug.Log("This works");
    }


}
