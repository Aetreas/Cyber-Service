using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyBehavior : MonoBehaviour
{
    public static CurrencyBehavior instance;

    public Text fixText;
    public Text scrapText;

    int fixcurrency = 0;
    int scrapcurrency = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        fixText.text = "Percentage: " + fixcurrency.ToString() + "%";
        scrapText.text = "Money: " + scrapcurrency.ToString() + "$";
    }

    public void AddCurrencyFix()
    {
        fixcurrency += 50;
        fixText.text = "Percentage: " + fixcurrency.ToString() + "%";
    }
    public void AddCurrencyScrap()
    {
        scrapcurrency += 50;
        scrapText.text = "Money: " + scrapcurrency.ToString() + "$";
    }
}
