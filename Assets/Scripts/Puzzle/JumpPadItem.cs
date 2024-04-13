using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadItem : MonoBehaviour
{
    [SerializeField] GameObject FixingKey;

    private void OnTriggerEnter(Collider other)
    {
        JumpPadPuzzle.instance.HasGateKey();
        FixingKey.SetActive(false);
    }
}
