using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchPuzzle2 : MonoBehaviour
{
    public static SwitchPuzzle2 instance;

    public GameObject FixBox;
    public GameObject FixDialogueBox;
    public GameObject ErrorDialogueBox;
    public bool fixInput1 = false;
    public bool fixInput2 = false;
    public bool fixInput3 = false;
    public bool fixInput4 = false;
    public bool gateRemain = true;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FixBox.SetActive(true);
        ErrorDialogueBox.SetActive(false);
        FixDialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Interact"))
        //  {
        //    uiInput = true;
        // }

        //   if (Input.GetButtonUp("Interact"))
        //   {
        //      uiInput = false;
        //  }
        //     if (Input.GetKeyDown(KeyCode.Backspace))
        //       {
        //        fixInput = false;
        //   }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gateRemain == true)
        {
            FixDialogueBox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FixDialogueBox.SetActive(false);
        ErrorDialogueBox.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (fixInput1 == true && fixInput2 == true)
            {
                OpenGate();
                FixDialogueBox.SetActive(false);
                DestroyGate();
            }
            else
            {
                FixDialogueBox.SetActive(false);
                ErrorDialogueBox.SetActive(true);
            }
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenGate()
    {
        FixBox.SetActive(false);
    }

    public void ActivatedSwitch1()
    {
        fixInput1 = true;
    }
    public void ActivatedSwitch2()
    {
        fixInput2 = true;
    }
    public void ActivatedSwitch3()
    {
        fixInput3 = true;
    }
    public void ActivatedSwitch4()
    {
        fixInput4 = true;
    }
    public void DestroyGate()
    {
        gateRemain = false;
    }
}
