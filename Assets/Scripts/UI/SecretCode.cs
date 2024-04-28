using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretCode : MonoBehaviour
{
    public GameObject SecretCodeBox;
    public GameObject SecretCodeInteract;
    public bool HasTextRun;
    public bool SecretInput;

    private void Start()
    {
        SecretCodeBox.SetActive(false);
        SecretCodeInteract.SetActive(false);
        SecretInput = false;
        HasTextRun = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (HasTextRun == false)
        {
            SecretCodeInteract.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SecretCodeInteract.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
            SecretInput = true;
        }
        if (SecretInput == true && HasTextRun == false)
        {
            SecretInteract();
            SecretCodeInteract.SetActive(false);
            HasTextRun= true;
        }
    }
    private void SecretInteract()
    {
        SecretCodeBox.SetActive(true);
        //ThirdPersonMovement.Instance.FreezePlayer();
        CurrencySystem.instance.SecretReward();
    }
}
