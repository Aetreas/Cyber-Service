using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject InteractBox;
    public GameObject ErrorBox;
    public ThirdPersonMovement pc;
    public bool uiInput = false;



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
        if (uiInput == true && pc.totalbots == 8)
        {
            OpenMenu();
            InteractBox.SetActive(false);
        }
        else if (uiInput == true && pc.totalbots != 8)
        {
            uiInput = false;
            ErrorBox.SetActive(true);
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenMenu()
    {
        dialogBox.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        //ThirdPersonMovement.Instance.FreezePlayer();
        Time.timeScale = 0f;
    }
    }
