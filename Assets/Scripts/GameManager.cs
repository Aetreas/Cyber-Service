using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }

    public UnitHP playerHP = new UnitHP(100, 100);
    public UnitHP enemyHP = new UnitHP(50, 50);
    
    void Awake()
    {
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

}
