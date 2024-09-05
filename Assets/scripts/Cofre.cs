using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject chocolatada;
    public KeyCode teclaParaAbrir = KeyCode.E; 
    private bool estaAbierto = false;

    void Start()
    {
        if (chocolatada != null)
        {
            chocolatada.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaParaAbrir))
        {
            AbrirCofre();
        }
    }

    void AbrirCofre()
    {
        if (estaAbierto)
        {
            Debug.Log("El loot del cofre respawneo :O!.");
            estaAbierto = false;
            return;
        }

        estaAbierto = true;
        Debug.Log("El cofre se ha abierto.");

        int resultado = Random.Range(50, 100 + 1);

        if (resultado == 1 && chocolatada != null)
        {
            chocolatada.SetActive(true);
            Debug.Log("El cofre contiene un objeto.");
        }
        else
        {
            if (chocolatada != null)
            {
                chocolatada.SetActive(false);
            }
            Debug.Log("El cofre está vacío.");
        }
    }
}