using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    public static LaunchPad Instance;
    [SerializeField] Transform tp;
    [SerializeField] GameObject player;
    public GameObject dialogueBox;
    //public bool input;

    void Awake()
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
        
    }

    public void LaunchPadMove()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        GetComponent<CharacterController>().enabled  = false;
        
        yield return new WaitForSeconds(0.5f);
        
        player.transform.position = new Vector3(

           tp.transform.position.x,

           tp.transform.position.y,

           tp.transform.position.z

       );

       GetComponent<CharacterController>().enabled = true;
       TPPromot.Instance.StopDialogue();

       Debug.Log("TP");
    }
}
