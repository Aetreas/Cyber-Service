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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            ec.EnemyTakeDamage(20);
            Debug.Log(GameManager.gameManager.enemyHP.Health);
        }
    }
}
