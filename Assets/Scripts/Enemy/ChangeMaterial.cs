using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour //THIS SCRIPT ISNT USED BY ANYTHING; RESULT OF MATERIAL SWAPPING ANNOYINGNESS
{
    public static ChangeMaterial Instance;
    public GameObject hostileMesh;
    
    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MaterialSwap()
    {
        Destroy(hostileMesh.gameObject);
        Debug.Log("a");
    }
}
