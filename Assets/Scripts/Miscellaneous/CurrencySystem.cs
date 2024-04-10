using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;
    public const string Coins = "Coi";
    public static int coins = 0;

    [SerializeField] private int price;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateCoins()
    {
        PlayerPrefs.SetInt("Coi", coins);
        coins = PlayerPrefs.GetInt("Coi");
        PlayerPrefs.Save();
    }
    public void AddCurrencyFix()
    {
        coins += 50;
        UpdateCoins();
    }
    public void AddCurrencyScrap()
    {
        coins += 100;
        UpdateCoins();
    }

    public void Buy()
    {
        if (coins >= price)
        {
            coins -= price;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic();
        }
    }
    public void CurrencyReward()
    {
        coins += 500;
        UpdateCoins();
    }
}
