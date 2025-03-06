using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterSeconds : MonoBehaviour
{
    public float seconds;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }
    
    void Update()
    {
        if (Time.time - startTime > seconds)
        {
            Destroy(gameObject);
        }
    }
}
