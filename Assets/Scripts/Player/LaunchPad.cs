using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    public static LaunchPad Instance;
    public Transform[] waypoint;
    public int targetPoint;
    public float speed = 15f;
    //public bool input;

    void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchPadMove()
    {
    
    }

    //IEnumerator Launch()
    //{
    
    //}
}
