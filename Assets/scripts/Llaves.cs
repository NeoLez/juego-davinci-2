using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour
{
    public string nombreLlave = "LlaveCofre"; 

    [Header("Sonido")]
    public AudioClip sonidoRecoger; 

    private bool jugadorCerca = false;

    private void Start() {
        Manager.Instance.playerInput.OnPressedInteract += Interacted;
    }

    private void Interacted() {
        if (jugadorCerca)
        {
            RecogerLlave();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona 'F' para recoger la llave.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }

    private void RecogerLlave()
    {
        GameManager.Instance.ObtenerLlave(nombreLlave);
        Debug.Log("¡Llave recogida!");

        if (sonidoRecoger != null)
        {
            GameManager.Instance.ReproducirSonido(sonidoRecoger);
        }

        Manager.Instance.playerInput.OnPressedInteract -= Interacted;
        Destroy(gameObject); 
    }
}
