using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueFlagSystem : MonoBehaviour
{
    public static DialogueFlagSystem instance;
    public bool didScrap;
    public bool didfix;

    private void Awake()
    {
        instance = this;
    }
    public void ScrapDialogue()
    {
        didScrap = true;
    }
    public void FixDialogue()
    {
        didfix = true;
    }
}
