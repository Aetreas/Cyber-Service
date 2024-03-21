using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{

    public ThirdPersonMovement pc;
    public GameObject healthKit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pc.PlayerHeal(40);
            Debug.Log(GameManager.gameManager.playerHP.Health);
            healthKit.SetActive(false);
        }
    }
}
