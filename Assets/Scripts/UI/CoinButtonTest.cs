using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTest : MonoBehaviour
{
    [SerializeField] Button _Addtest;
    [SerializeField] Button _Removetest;
    // Start is called before the first frame update
    void Start()
    {
        _Addtest.onClick.AddListener(AddCoin);
        _Removetest.onClick.AddListener(RemoveCoin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin()
    {
        CurrencySystem.coins += 50;
        CurrencySystem.UpdateCoins();
    }
    public void RemoveCoin()
    {
        CurrencySystem.coins -= 50;
        CurrencySystem.UpdateCoins();
    }
}
