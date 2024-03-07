using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _startGame;
    [SerializeField] Button _quitGame;

    // Start is called before the first frame update
    void Start()
    {
        _startGame.onClick.AddListener(StartGame);
        _quitGame.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    private void StartGame()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.SampleScene);
    }

    private void QuitGame()
    {
        ScenesManager.Instance.QuitGame();
    }
}
