using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScripts : MonoBehaviour
{
    public GameObject PromptBox;
    // Start is called before the first frame update
    void Start()
    {
        PromptBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
        if (Input.GetButtonDown("Interact"))
        {
            CurrencyBehavior.instance.AddCurrencyFix();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CurrencyBehavior.instance.AddCurrencyScrap();
        }
    }
}
