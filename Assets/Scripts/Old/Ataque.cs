using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public float tiempoEntreAtaques = 1f;
    private bool puedeAtacar = true;

    private float tiempo = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeAtacar)
        {
            Atacar();
            Debug.Log("asd");
        }
        if (!puedeAtacar)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= tiempoEntreAtaques)
            {
                tiempo = 0f;
                puedeAtacar = true;
            }
        }

    }

    void Atacar()
    {
        Debug.Log("El personaje ataca.");
        puedeAtacar = false;
    }

    void countTime()
    {
        Debug.Log("Cooldown");
        puedeAtacar = true;
    }
}