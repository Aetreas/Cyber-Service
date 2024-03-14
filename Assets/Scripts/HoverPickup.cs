using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPickup : MonoBehaviour
{
    [SerializeField] GameObject hoverPickup;
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
        ThirdPersonMovement.Instance.HoverObtained();
        hoverPickup.SetActive(false);
    }
}
