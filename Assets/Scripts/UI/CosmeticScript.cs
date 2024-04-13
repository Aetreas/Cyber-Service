using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticScript : MonoBehaviour
{
    public static CosmeticScript inst;

    public GameObject cosmetic1;
    public GameObject cosmetic2;
    public GameObject cosmetic3;
    public GameObject cosmetic4;
    public GameObject cosmetic5;
    public GameObject cosmetic6;
    public static bool BoughtItem1 { get; set; }
    public static bool BoughtItem2 { get; set; }
    public static bool BoughtItem3 { get; set; }
    public static bool BoughtItem4 { get; set; }
    public static bool BoughtItem5 { get; set; }
    public static bool BoughtItem6 { get; set; }

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (BoughtItem1 == false)
        {
            cosmetic1.SetActive(false);
        }
        if (BoughtItem2 == false)
        {
            cosmetic2.SetActive(false);
        }
        if (BoughtItem3 == false)
        {
            cosmetic3.SetActive(false);
        }
        if (BoughtItem4 == false)
        {
            cosmetic4.SetActive(false);
        }
        if (BoughtItem5 == false)
        {
            cosmetic5.SetActive(false);
        }
        if (BoughtItem6 == false)
        {
            cosmetic6.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivateCosmetic1()
    {
        cosmetic1.SetActive(true);
        BoughtItem1 = true;
    }
    public void ActivateCosmetic2()
    {
        cosmetic2.SetActive(true);
        BoughtItem2 = true;
    }
    public void ActivateCosmetic3()
    {
        cosmetic3.SetActive(true);
        BoughtItem3 = true;
    }
    public void ActivateCosmetic4()
    {
        cosmetic4.SetActive(true);
        BoughtItem4 = true;
    }
    public void ActivateCosmetic5()
    {
        cosmetic5.SetActive(true);
        BoughtItem5 = true;
    }
    public void ActivateCosmetic6()
    {
        cosmetic6.SetActive(true);
        BoughtItem6 = true;
    }
}
