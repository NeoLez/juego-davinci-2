using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using New;

public class GoToScene : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver; // Referencia al menú de Game Over
    private Health health; // Referencia al script CombateJugador
    public AudioSource backgroundMusic; // Música de fondo normal
    public AudioSource birdSounds; // Sonidos de pájaros
    public AudioSource gameOverMusic; // Nueva música después del fade out
    public float fadeDuration = 1.5f; // Duración del fade out

    private void Start()
    {
        // Busca al jugador por su tag y obtiene el componente Health
        health = Manager.Instance.player.GetComponent<Health>();

        // Suscribe el método ActivarMenu al evento MuerteJugador
        health.OnDeathEvent += ActivarMenu;
    }

    // Método que se activa cuando el jugador muere
    private void ActivarMenu()
    {
        menuGameOver.SetActive(true); // Muestra el menú de inmediato
        Time.timeScale = 0; // Pausa el tiempo de juego

        // Iniciar la reducción de volumen de los audios
        if (backgroundMusic != null || birdSounds != null)
        {
            StartCoroutine(FadeOutSounds());
        }
    }

    private IEnumerator FadeOutSounds()
    {
        float startVolumeMusic = backgroundMusic != null ? backgroundMusic.volume : 0;
        float startVolumeBirds = birdSounds != null ? birdSounds.volume : 0;

        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            if (backgroundMusic != null)
                backgroundMusic.volume = Mathf.Lerp(startVolumeMusic, 0, timer / fadeDuration);

            if (birdSounds != null)
                birdSounds.volume = Mathf.Lerp(startVolumeBirds, 0, timer / fadeDuration);

            yield return null;
        }

        // Asegurar que el volumen llegue a 0 y detener el sonido
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = 0;
            backgroundMusic.Stop();
        }

        if (birdSounds != null)
        {
            birdSounds.volume = 0;
            birdSounds.Stop();
        }

        // Iniciar la nueva música de Game Over
        if (gameOverMusic != null)
        {
            gameOverMusic.volume = 1f; // Volumen inicial
            gameOverMusic.Play();
        }
    }

    // Método para reiniciar el nivel actual
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para cargar el menú inicial
    public void MenuInicial(string nombre)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre);
    }
}
