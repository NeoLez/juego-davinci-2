using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private static AudioSource globalAudioSource; 
    public AudioClip hoverSound;
    public AudioClip clickSound;
    [Range(0f, 3f)] public float volume = 2f;

    public GameObject menuOpciones; 
    public GameObject menuCreditos; 

    public bool isOptionsButton = false; 
    public bool isCreditsButton = false; 

    private TMPro.TextMeshProUGUI buttonText;
    public Color hoverColor = Color.yellow; 
    private Color originalColor;

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

        buttonText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (buttonText != null)
        {
            originalColor = buttonText.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            globalAudioSource.PlayOneShot(hoverSound, volume);

        if (buttonText != null)
            buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
            buttonText.color = originalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
            globalAudioSource.PlayOneShot(clickSound, volume);

        if (buttonText != null)
            buttonText.color = originalColor; // Restaurar el color después del clic

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
        yield return new WaitForSeconds(clickSound.length); 
        menu.SetActive(true); 
    }
}