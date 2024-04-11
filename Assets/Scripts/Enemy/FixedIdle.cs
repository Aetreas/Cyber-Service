using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedIdle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IdleStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IdleStart()
    {
        yield return new WaitForSeconds(1.5f);
        
        GetComponent<Animator>().SetBool("FixedAnimation", false);
        GetComponent<Animator>().SetBool("Idle", true);
    }
}






