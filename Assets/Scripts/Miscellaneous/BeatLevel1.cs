using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLevel1 : MonoBehaviour
{
    public bool Level1beat;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact") && EnemyCounter.Instance.EnemyCount == 0)
        {
            DialogueFlagSystem.instance.PlayerPrefIntFunction();
        }
    }
}
