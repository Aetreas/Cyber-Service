using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchItem4 : MonoBehaviour
{
    public GameObject FixDialogueBox;
    public bool interact;

    private void Start()
    {
        FixDialogueBox.SetActive(false);
        interact = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (interact == false)
        {
            FixDialogueBox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (interact == false)
        {
            FixDialogueBox.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            SwitchPuzzle.instance.ActivatedSwitch4();
            SwitchPuzzle2.instance.ActivatedSwitch4();
            FixDialogueBox.SetActive(false);
            interact = true;
        }
    }
}
