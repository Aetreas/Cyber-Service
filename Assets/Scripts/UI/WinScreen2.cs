using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinScreen2 : MonoBehaviour
{
    public static WinScreen2 Instance;
    public GameObject dialogBox;
    public GameObject InteractBox;
    public GameObject ErrorBox;
    public GameObject QuotaFixBox;
    public GameObject QuotaScrapBox;
    public ThirdPersonMovement pc;
    public bool uiInput = false;



    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        ErrorBox.SetActive(false);
        QuotaFixBox.SetActive(false);
        QuotaScrapBox.SetActive(false);
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
        if (uiInput == true && pc.totalbots == 9)
        {
            OpenMenu();
            ThirdPersonMovement.Instance.LevelEndTrigger();
            InteractBox.SetActive(false);
        }
        else if (uiInput == true && pc.totalbots != 9)
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
        ThirdPersonMovement.Instance.FreezePlayer();
    }
    public void FixEnding()
    {
        QuotaFixBox.SetActive(true);
    }
    public void ScrapEnding()
    {
        QuotaScrapBox.SetActive(true);
        CurrencySystem.instance.CurrencyReward();
    }
}

