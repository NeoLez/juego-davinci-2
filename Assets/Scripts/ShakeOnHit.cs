using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class ShakeOnHit : MonoBehaviour
{
    [SerializeField] private new Animation animation;
    [SerializeField] private ParticleSystem onBreakParticles;
    private void Start()
    {
        Health health = GetComponent<Health>();
        health.OnHitEvent += Shake;
        health.OnDeathEvent += BreakParticles;
    }

    private void Shake()
    {
        animation.Play();
    }

    private void BreakParticles()
    {
        onBreakParticles.Emit(100);
    }
}
