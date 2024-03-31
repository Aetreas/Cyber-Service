using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public EnemyController ec;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Enemy" && wc.isAttacking)
        {
            trigger.gameObject.GetComponent<EnemyController>().EnemyTakeDamage(6);
            Debug.Log("collision detected");
        }
    }
}
