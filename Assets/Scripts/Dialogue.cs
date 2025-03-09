using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable]
public class HighlightedWord
{
    public string word;  // Palabra a resaltar
    public Color color;  // Color personalizado desde el Inspector
}

public class Dialogue : MonoBehaviour
{
    private AudioSource audioSource;
    public bool didDialogueStart;
    private int lineIndex;

    [SerializeField] private AudioClip[] dialogueVoices;
    [SerializeField] private float typingTime;
    [SerializeField] private int charsToPlaySound;

    [SerializeField] private GameObject dialogueMark;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private HighlightedWord[] highlightedWords;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public bool Interact()
    {
        if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == GetProcessedText(dialogueLines[lineIndex]))
        {
            NextDialogueLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = GetProcessedText(dialogueLines[lineIndex]);
        }
        return didDialogueStart;
    }

    private void SelectAudioClip()
    {
        if (dialogueVoices.Length > lineIndex && dialogueVoices[lineIndex] != null)
        {
            audioSource.clip = dialogueVoices[lineIndex];
        }
        else
        {
            audioSource.clip = null;
        }
    }

    private IEnumerator ShowLine()
    {
        SelectAudioClip();
        dialogueText.text = string.Empty;
        int charIndex = 0;
        string fullText = dialogueLines[lineIndex];
        
        while (charIndex < fullText.Length)
        {
            dialogueText.text = GetProcessedText(fullText.Substring(0, charIndex + 1));
            
            if (charIndex % charsToPlaySound == 0 && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            charIndex++;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private string GetProcessedText(string partialText)
    {
        foreach (var highlighted in highlightedWords)
        {
            string colorCode = ColorUtility.ToHtmlStringRGB(highlighted.color);
            partialText = partialText.Replace(highlighted.word, $"<color=#{colorCode}>{highlighted.word}</color>");
        }
        return partialText;
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void SetDialogMarkState(bool state)
    {
        dialogueMark.SetActive(state);
    }
}
