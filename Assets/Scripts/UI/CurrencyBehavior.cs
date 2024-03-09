using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyBehavior : MonoBehaviour
{
    public static CurrencyBehavior instance;

    public Text fixText;
    public Text scrapText;

   public int fixcurrency = 0;
   public int scrapcurrency = 0;
   [SerializeField] private int itemPrice;

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

    public void Buy()
    {
        if (scrapcurrency >= itemPrice)
        {
            scrapcurrency -= itemPrice;
            scrapText.text = "Money: " + scrapcurrency.ToString() + "$";
        }
    }
}
