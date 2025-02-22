using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioSource audioSource;
    public AudioClip hoverSound; 
    public AudioClip clickSound; 
    [Range(0f, 3f)] public float volume = 2f; 

    public AudioSource backgroundMusic; // Referencia a la música de fondo
    public float fadeDuration = 1.5f; // Duración del fade out

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.enabled = true;
        audioSource.playOnAwake = false; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            audioSource.PlayOneShot(hoverSound, volume);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound, volume);

        // Iniciar la reducción de volumen de la música de fondo
        if (backgroundMusic != null)
        {
            StartCoroutine(FadeOutMusic());
        }
    }

    private IEnumerator FadeOutMusic()
    {
        float startVolume = backgroundMusic.volume;

        while (backgroundMusic.volume > 0)
        {
            backgroundMusic.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        backgroundMusic.volume = 0; 
        backgroundMusic.Stop(); 
    }
}
