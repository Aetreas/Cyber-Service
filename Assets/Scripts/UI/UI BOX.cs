using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIBOX : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject InteractBox;
    public GameObject virtualCursor;
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
        if (Input.GetButtonDown("Back"))
        {
            uiInput = false;
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractBox.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        InteractBox.SetActive(false);
        dialogBox.SetActive(false);
        uiInput = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            uiInput = true;
            Time.timeScale = 0;
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
        virtualCursor.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu()
    {
        dialogBox.SetActive(false);
        virtualCursor.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
