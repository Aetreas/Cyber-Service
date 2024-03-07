using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectTest : MonoBehaviour
{
    public GameObject dialogBox;
    public bool uiInput = false;
    


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            uiInput = true;
        }

        if (Input.GetButtonUp("Interact"))
        {
            uiInput = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(uiInput == true)
        {
            OpenMenu();
        }
    
        //Debug.Log ("Player is in the collider.");
    }

    public void OpenMenu()
    {
        dialogBox.SetActive(true);
        
    }

    public void CloseMenu()
    {
        dialogBox.SetActive(false);
        
    }
}
