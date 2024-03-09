using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticScript : MonoBehaviour
{
    public static CosmeticScript inst;

    public GameObject cosmetic;

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cosmetic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivateCosmetic()
    {
        cosmetic.SetActive(true);
    }
}
