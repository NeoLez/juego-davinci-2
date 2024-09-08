using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject chocolatada;
    public KeyCode teclaParaAbrir = KeyCode.E;
    private bool estaAbierto = false;
    bool canBeOpened = false;

    void Start()
    {
        if (chocolatada != null)
        {
            chocolatada.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(teclaParaAbrir) && canBeOpened)
            AbrirCofre();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Manager.player)
            canBeOpened = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Manager.player)
            canBeOpened = false;
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

        int resultado = Random.Range(0, 2);

        if (resultado == 1)
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
            Debug.Log("El cofre est� vac�o.");
        }
    }
}