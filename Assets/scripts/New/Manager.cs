using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    private void Awake() {
        if(Instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    
    
    
    public GameObject player;
    public bool foundKeyOne;
    public bool foundKeyTwo;


    public class DeltaTimeEventArgs : EventArgs
    {
        public float deltaTime;
        public DeltaTimeEventArgs(float deltaTime) {
            this.deltaTime = deltaTime;
        }
    }
    public EventHandler<DeltaTimeEventArgs> UpdateEvent;
    public EventHandler<DeltaTimeEventArgs> FixedUpdateEvent;
    private void Update() {
        UpdateEvent?.Invoke(this, new DeltaTimeEventArgs(Time.deltaTime));
    }

    private void FixedUpdate() {
        FixedUpdateEvent?.Invoke(this, new DeltaTimeEventArgs(Time.fixedDeltaTime));
    }
}
