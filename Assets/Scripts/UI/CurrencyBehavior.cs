using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyBehavior : MonoBehaviour
{
    public static CurrencyBehavior instance;

    public Text scrapText;

   public int scrapcurrency = 0;
   [SerializeField] private int itemPrice;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scrapText.text = scrapcurrency.ToString();
    }

    public void AddCurrencyFix()
    {
        scrapcurrency += 50;
        scrapText.text = scrapcurrency.ToString();
    }
    public void AddCurrencyScrap()
    {
        scrapcurrency += 100;
        scrapText.text = scrapcurrency.ToString();
    }

    public void Buy()
    {
        if (scrapcurrency >= itemPrice)
        {
            scrapcurrency -= itemPrice;
            scrapText.text = scrapcurrency.ToString();
            CosmeticScript.inst.ActivateCosmetic1();
        }
    }
}
