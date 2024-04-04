using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPickup : MonoBehaviour
{
    [SerializeField] GameObject dashPickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        ThirdPersonMovement.Instance.DashObtained();
        dashPickup.SetActive(false);
    }
}
