using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScripts : MonoBehaviour
{
    public GameObject PromptBox;
    public GameObject Bot;
    public bool currencyfixInteract = false;
    public bool currencyscrapInteract = false;
    public bool isFixed;

    // Start is called before the first frame update
    void Start()
    {
        PromptBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            currencyfixInteract = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currencyscrapInteract = true;
        }

        if (Input.GetButtonUp("Interact"))
        {
            currencyfixInteract = false;
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            currencyscrapInteract = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        PromptBox.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        PromptBox.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (currencyfixInteract == true)
        {
            CurrencyBehavior.instance.AddCurrencyFix();
            Bot.GetComponent<BoxCollider>().enabled = false;
            PromptBox.SetActive(false);
        }
        if (currencyscrapInteract == true)
        {
            CurrencyBehavior.instance.AddCurrencyScrap();
            Bot.SetActive(false);
        }
    }
}
