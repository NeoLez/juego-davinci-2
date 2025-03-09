using System.Collections;
using UnityEngine;
using System.Diagnostics; // Para cerrar el proceso

public class PrankCrash : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript; // Referencia al script de diálogo
    [SerializeField] private GameObject dialoguePanel; // Panel de diálogo a monitorear
    [SerializeField] private AudioClip explosionSound; // Sonido de explosión
    private AudioSource audioSource;

    private bool prankTriggered = false;
    private bool dialogueWasActive = false; // ✅ Nuevo: Detectar si el diálogo se abrió al menos una vez

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (!prankTriggered && dialogueScript != null && dialoguePanel != null)
        {
            // ✅ Si el diálogo se abrió al menos una vez, activamos la detección del cierre
            if (dialoguePanel.activeSelf)
            {
                dialogueWasActive = true;
            }

            // ✅ Solo activamos el prank si el diálogo se cerró después de haber estado abierto
            if (dialogueWasActive && !dialoguePanel.activeSelf && dialogueScript.didDialogueStart == false)
            {
                StartCoroutine(TriggerPrank());
                prankTriggered = true; // Evita múltiples activaciones
            }
        }
    }

    private IEnumerator TriggerPrank()
    {
        yield return new WaitForSeconds(0.5f); // Pequeña pausa antes del sonido
        audioSource.PlayOneShot(explosionSound, 1.5f); // Sonido fuerte de explosión

        yield return new WaitForSeconds(2f); // Espera a que suene la explosión

        // 💥 Cerrar el juego
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
#else
        Process.GetCurrentProcess().Kill(); // Cierra el juego forzadamente
#endif
    }
}
