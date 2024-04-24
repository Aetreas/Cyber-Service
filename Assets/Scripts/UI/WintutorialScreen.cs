using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WintutorialScreen : MonoBehaviour
{
    public static WintutorialScreen Instance;
    public GameObject dialogBox;
    public GameObject InteractBox;
    public GameObject ErrorBox;
    public ThirdPersonMovement pc;
    public GameObject virtualCursor;
    public PauseMenu pauseScript;
    public bool uiInput = false;



    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        ErrorBox.SetActive(false);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractBox.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        InteractBox.SetActive(false);
        ErrorBox.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            uiInput = true;
        }
        if (uiInput == true && pc.totalbots == 1)
        {
            OpenMenu();
            ThirdPersonMovement.Instance.LevelEndTrigger();
            InteractBox.SetActive(false);
        }
        else if (uiInput == true && pc.totalbots != 1)
        {
            uiInput = false;
            ErrorBox.SetActive(true);
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenMenu()
    {
        dialogBox.SetActive(true);
        virtualCursor.SetActive(true);
        pauseScript.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        ThirdPersonMovement.Instance.FreezePlayer();
    }
}

