using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchItem3 : MonoBehaviour
{
    public GameObject FixDialogueBox;
    public bool interact;
    [SerializeField] private AudioClip interactSound;

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
            SoundEffectScripts.instance.PlaySoundClip(interactSound, transform, 1f);
            SwitchPuzzle.instance.ActivatedSwitch3();
            SwitchPuzzle2.instance.ActivatedSwitch3();
            FixDialogueBox.SetActive(false);
            interact = true;
        }
    }
}
