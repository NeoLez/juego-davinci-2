using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozo : MonoBehaviour
{
    public int costoMonedas = 5;
    private bool jugadorCerca = false;
    private int intentosFallidos = 0;

    [Header("Configuración del castigo")]
    public int maxIntentosFallidos = 3; // Intentos fallidos antes del castigo
    public List<GameObject> enemigosPosibles; // Enemigos que aparecerán
    public List<Transform> spawnPointsEnemigos; // Lugares donde aparecerán

    [Header("Objetos del Pozo")]
    public List<GameObject> objetosPosibles;
    public Transform spawnPoint;

    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip sonidoError;
    public AudioClip sonidoExito;
    public AudioClip sonidoCastigo;
    [Range(0f, 1f)] public float volumenSonido = 1f; // Ajuste de volumen en el inspector

    private void Start() {
        Manager.Instance.playerInput.OnPressedInteract += Interacted;
    }

    private void Interacted() {
        if (jugadorCerca)
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
            intentosFallidos = 0; // Reseteamos los intentos fallidos
            ReproducirSonido(sonidoExito);
        }
        else
        {
            intentosFallidos++;
            ReproducirSonido(sonidoError);

            if (intentosFallidos >= maxIntentosFallidos)
            {
                ActivarCastigo();
                intentosFallidos = 0; // Reiniciamos el contador de intentos fallidos
            }
        }
    }

    private void SoltarObjetoAleatorio()
    {
        if (spawnPoint == null || objetosPosibles.Count == 0) return;

        int indiceAleatorio = Random.Range(0, objetosPosibles.Count);
        Vector3 posicionSpawn = spawnPoint.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        Instantiate(objetosPosibles[indiceAleatorio], posicionSpawn, Quaternion.identity);
    }

    private void ActivarCastigo()
    {
        if (spawnPointsEnemigos.Count == 0 || enemigosPosibles.Count == 0) return;

        int cantidadEnemigos = Mathf.Min(enemigosPosibles.Count, spawnPointsEnemigos.Count);

        for (int i = 0; i < cantidadEnemigos; i++)
        {
            Instantiate(enemigosPosibles[i], spawnPointsEnemigos[i].position, Quaternion.identity);
        }

        ReproducirSonido(sonidoCastigo);
    }

    private void ReproducirSonido(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip, volumenSonido);
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
