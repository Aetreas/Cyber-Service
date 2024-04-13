using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpPadPuzzle : MonoBehaviour
{
    public static JumpPadPuzzle instance;

    public GameObject FixBox;
    public GameObject FixDialogueBox;
    public GameObject ErrorDialogueBox;
    public GameObject BrokenMesh;
    public GameObject FixedMesh;
    public bool fixInput = false;
    public bool gateRemain = true;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FixBox.SetActive(false);
        BrokenMesh.SetActive(true);
        FixedMesh.SetActive(false);
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
        if (other.gameObject.tag == "Player" && gateRemain == true)
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
         if (fixInput == true)
            {
               OpenGate();
                FixDialogueBox.SetActive(false);
                DestroyGate();
            }
            else if (fixInput == false)
          {
                   FixDialogueBox.SetActive(false);
                  ErrorDialogueBox.SetActive(true);
          }
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenGate()
    {
        FixBox.SetActive(true);
        BrokenMesh.SetActive(false);
        FixedMesh.SetActive(true);
    }

    public void HasGateKey()
    {
        fixInput = true;
    }
    public void DestroyGate()
    {
        gateRemain = false;
    }
}
