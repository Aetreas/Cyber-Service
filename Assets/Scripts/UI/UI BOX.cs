using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIBOX : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject InteractBox;
    public bool uiInput = false;



    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            uiInput = false;
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractBox.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        InteractBox.SetActive(false);
        uiInput = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            uiInput = true;
        }
        if (uiInput == true)
        {
            OpenMenu();
            InteractBox.SetActive(false);
        }
        if (uiInput == false)
        {
            CloseMenu();
            InteractBox.SetActive(true);
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenMenu()
    {
        dialogBox.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        ThirdPersonMovement.Instance.FreezePlayer();
    }

    public void CloseMenu()
    {
        dialogBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        ThirdPersonMovement.Instance.UnFreezePlayer();
    }
}
