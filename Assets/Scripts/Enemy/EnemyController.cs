using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    //public GameObject enemyObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.enemyHP.Health <= 0) //death function
        {
            //Destroy(enemyObj);
        }
    }

    public void EnemyTakeDamage(int dmg)
    {
        GameManager.gameManager.enemyHP.DamageUnit(dmg);
    }
}
