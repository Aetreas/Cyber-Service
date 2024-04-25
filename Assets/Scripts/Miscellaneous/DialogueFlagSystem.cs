using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueFlagSystem : MonoBehaviour
{
    public static DialogueFlagSystem instance;
    public int didtheyScraporFix;

    private void Start()
    {
        didtheyScraporFix = 0;
    }
    private void Awake()
    {
        instance = this;
    }
    public void ScrapDialogue()
    {
        didtheyScraporFix = 1;
    }
    public void FixDialogue()
    {
        didtheyScraporFix = 2;
    }   
    public void PlayerPrefIntFunction()
    {
        PlayerPrefs.SetInt("score", didtheyScraporFix);
    }
}
