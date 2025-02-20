using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozo : MonoBehaviour
{
    public int costoMonedas = 5; 
    private bool jugadorCerca = false;

    [Header("Objetos del Pozo")]
    public List<GameObject> objetosPosibles; 
    public Transform spawnPoint; 

    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip sonidoError; 
    public AudioClip sonidoExito; 

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.F))
        {
            IntentarUsarPozo();
        }
    }

    private void IntentarUsarPozo()
    {
        if (GameManager.Instance.MonedasRecolectadas >= costoMonedas)
        {
            GameManager.Instance.SumarMoneda(-costoMonedas); 
            SoltarObjetoAleatorio();

            if (audioSource != null && sonidoExito != null)
            {
                audioSource.PlayOneShot(sonidoExito);
            }
        }
        else
        {
            if (audioSource != null && sonidoError != null)
            {
                audioSource.PlayOneShot(sonidoError);
            }
        }
    }

    private void SoltarObjetoAleatorio()
    {
        if (objetosPosibles.Count > 0)
        {
            int indiceAleatorio = Mathf.FloorToInt(Random.Range(0, objetosPosibles.Count)); 
            Vector3 posicionSpawn = spawnPoint.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0); 
            GameObject obh = Instantiate(objetosPosibles[indiceAleatorio], posicionSpawn, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}

