using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShops : MonoBehaviour
{
    public GameObject dialogBox;

    void Start()
    {
        dialogBox.SetActive(false);

    }

    void Update()
    {

    }

    public void DisplayDialog()
    {
        dialogBox.SetActive(true);
    }
    public void RemoveDialog()
    {
        dialogBox.SetActive(false);
    }
}
