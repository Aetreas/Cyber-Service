using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    public static TriggerTutorial Instance;
    public GameObject InteractBox;



    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
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
            InteractBox.SetActive(false);
        }
        //Debug.Log ("Player is in the collider.");
    }
}
