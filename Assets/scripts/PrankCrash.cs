using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PrankCrash : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript;
    [SerializeField] private AudioClip explosionSound;
    private AudioSource audioSource;

    private void Start() {
        dialogueScript.OnDialogueEnded += Explotar;
    }

    public void Explotar() {
        StartCoroutine(TriggerPrank());
    }
    
    private IEnumerator TriggerPrank()
    {
        yield return new WaitForSeconds(0.5f);
        Manager.Instance.PlaySound(explosionSound, 1.5f);

        yield return new WaitForSeconds(2f);
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Process.GetCurrentProcess().Kill();
#endif
    }
}
