using System;
using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class ParticleCulling : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    private static float checkFrequency = 2;
    private static float minDistance = 20;
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating(nameof(Cull), 0, checkFrequency);
    }

    private void Cull()
    {
        if((Manager.Instance.player.transform.position - transform.position).ToVector2().magnitude > minDistance)
            particleSystem.Stop();
        else if(particleSystem.isPaused)
            particleSystem.Play();
    }
}
