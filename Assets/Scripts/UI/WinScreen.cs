using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject windialog;
    public GameObject InteractBox;
    public bool uiInput = false;



    // Start is called before the first frame update
    void Start()
    {
        windialog.SetActive(false);
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
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            uiInput = true;
        }
        if (uiInput == true)
        {
            OpenWin();
            InteractBox.SetActive(false);
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenWin()
    {
        windialog.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        //ThirdPersonMovement.Instance.FreezePlayer();
    }
}
