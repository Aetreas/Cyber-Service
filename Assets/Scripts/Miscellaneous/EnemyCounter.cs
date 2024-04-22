using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance;
    public int EnemyCount;

    private void Awake()
    {
        Instance = this;
    }

    public void EnemiesLeft()
    {
        EnemyCount = EnemyCount - 1;
    }
}
