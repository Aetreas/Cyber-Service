using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPC_UI : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject ScrapBox;
    public GameObject FixBox;
    public GameObject InteractBox;
    public bool InInput = false;
    public int verification;



    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        verification = PlayerPrefs.GetInt("score");
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
            InInput = false;
        //    Time.timeScale = 1;
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
        ScrapBox.SetActive(false);
        FixBox.SetActive(false);
        InInput = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            InInput = true;
           // Time.timeScale = 0;
        }
        if (InInput == true)
        {
            OpenMenu();
            InteractBox.SetActive(false);
        }
        if (InInput == false)
        {
            CloseMenu();
            InteractBox.SetActive(true);
        }
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenMenu()
    {
        if (verification == 0)
        {
            dialogBox.SetActive(true);
        }
        else if (verification == 1)
        {
            ScrapBox.SetActive(true);
        }
        else if (verification == 2)
        {
            FixBox.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu()
    {
        dialogBox.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}