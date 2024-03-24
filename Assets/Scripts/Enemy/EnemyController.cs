using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public GameObject enemyObj;
    public GameObject FixScrapPrompt;
    public bool fixInteract = false;
    public bool scrapInteract = false;
    public bool enemyDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        FixScrapPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         //fix and scrap bool stuff
         if (Input.GetButtonDown("Interact"))
        {
            fixInteract = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            scrapInteract = true;
        }

        if (Input.GetButtonUp("Interact"))
        {
            fixInteract = false;
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            scrapInteract = false;
        }
        
        //death function
        if (GameManager.gameManager.enemyHP.Health <= 0) 
        {
            GetComponent<BoxCollider>().enabled = false;
            FixScrapPrompt.SetActive(true);
            enemyDown = true;
            //Destroy(enemyObj);
        }
    }

    public void EnemyTakeDamage(int dmg)
    {
        GameManager.gameManager.enemyHP.DamageUnit(dmg);
    }

    private void OnTriggerStay(Collider other)
    {
        if (fixInteract == true && enemyDown == true)
        {
            FixScrapPrompt.GetComponent<BoxCollider>().enabled = false;
            ThirdPersonMovement.Instance.AddHonor();
        }

        if (scrapInteract == true && enemyDown == true)
        {
            Destroy(enemyObj);
        }
    }
}
