using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public const string Coins = "Coins";
    public static int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.Save();
    }
}
