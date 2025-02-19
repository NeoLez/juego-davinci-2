using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour
{
    public string nombreLlave = "LlaveCofre"; 
    public KeyCode teclaParaRecoger = KeyCode.F; 

    [Header("Sonido")]
    public AudioClip sonidoRecoger; 

    private bool jugadorCerca = false;

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(teclaParaRecoger))
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

        Destroy(gameObject); 
    }
}
