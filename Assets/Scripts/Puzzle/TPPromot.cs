using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPromot : MonoBehaviour
{

    public GameObject dialogueBox;
    public static TPPromot Instance;

    // Start is called before the first frame update
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(true);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
        //dialogueBox.SetActive(false);
    //}

    public void StopDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
