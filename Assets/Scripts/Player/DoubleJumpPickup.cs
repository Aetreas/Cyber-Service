using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    [SerializeField] GameObject jumpPickup;
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
        ThirdPersonMovement.Instance.DoubleJumpObtained();
        jumpPickup.SetActive(false);
    }
}
