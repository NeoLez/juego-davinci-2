using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private static AudioSource globalAudioSource; // Audio global para evitar cortes
    public AudioClip hoverSound;
    public AudioClip clickSound;
    [Range(0f, 3f)] public float volume = 2f;

    public GameObject menuOpciones; // Referencia al menú de opciones
    public GameObject menuCreditos; // Referencia al menú de créditos

    public bool isOptionsButton = false; // Marcar en el Inspector si es el botón de opciones
    public bool isCreditsButton = false; // Marcar en el Inspector si es el botón de créditos

    private void Start()
    {
        if (globalAudioSource == null)
        {
            GameObject audioManager = GameObject.Find("AudioManager");
            if (audioManager == null)
            {
                audioManager = new GameObject("AudioManager");
                globalAudioSource = audioManager.AddComponent<AudioSource>();
                DontDestroyOnLoad(audioManager);
            }
            else
            {
                globalAudioSource = audioManager.GetComponent<AudioSource>();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            globalAudioSource.PlayOneShot(hoverSound, volume);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
            globalAudioSource.PlayOneShot(clickSound, volume);

        if (isOptionsButton && menuOpciones != null)
        {
            StartCoroutine(DelayOpenMenu(menuOpciones));
        }
        else if (isCreditsButton && menuCreditos != null)
        {
            StartCoroutine(DelayOpenMenu(menuCreditos));
        }
    }

    private IEnumerator DelayOpenMenu(GameObject menu)
    {
        yield return new WaitForSeconds(clickSound.length); // Esperar a que termine el sonido
        menu.SetActive(true); // Activar el menú después del sonido
    }
}
