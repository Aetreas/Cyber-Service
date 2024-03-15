using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixItem : MonoBehaviour
{
    [SerializeField] GameObject FixingKey;

    private void OnTriggerEnter(Collider other)
    {
        FixScript.instance.HasGateKey();
        FixingKey.SetActive(false);
    }
}
