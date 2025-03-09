using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrillaSonido : MonoBehaviour
{
    public AudioClip sonidoOlas;
    public float distanciaMaxima = 10f;

    void Start()
    {
        GameObject[] orillas = GameObject.FindGameObjectsWithTag("Orilla");

        foreach (GameObject orilla in orillas)
        {
            AudioSource audioSource = orilla.AddComponent<AudioSource>();
            audioSource.clip = sonidoOlas;
            audioSource.loop = true;
            audioSource.spatialBlend = 1.0f; // Sonido 3D
            audioSource.maxDistance = distanciaMaxima;
            audioSource.Play();
        }
    }
}
