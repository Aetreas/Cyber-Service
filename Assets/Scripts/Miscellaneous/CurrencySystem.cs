using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;
    public const string Coins = "Coi";
    public static int coins = 0;

    [SerializeField] private int price1;
    [SerializeField] private int price2;
    [SerializeField] private int price3;
    [SerializeField] private int price4;
    [SerializeField] private int price5;
    [SerializeField] private int price6;

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

    public void Buy1()
    {
        if (coins >= price1)
        {
            coins -= price1;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic1();
        }
    }
    public void Buy2()
    {
        if (coins >= price2)
        {
            coins -= price2;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic2();
        }
    }
    public void Buy3()
    {
        if (coins >= price3)
        {
            coins -= price3;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic3();
        }
    }
    public void Buy4()
    {
        if (coins >= price4)
        {
            coins -= price4;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic4();
        }
    }
    public void Buy5()
    {
        if (coins >= price5)
        {
            coins -= price5;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic5();
        }
    }
    public void Buy6()
    {
        if (coins >= price6)
        {
            coins -= price6;
            UpdateCoins();
            CosmeticScript.inst.ActivateCosmetic6();
        }
    }
    public void ScrapReward()
    {
        coins += 500;
        UpdateCoins();
    }
    public void FixReward()
    {
        coins += 2000;
        UpdateCoins();
    }
    public void SecretReward()
    {
        coins += 5000;
        UpdateCoins();
    }
}
