using System.Collections;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;
    
    
    [SerializeField]
    private GameObject dialogueMark;

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines;

    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TMP_Text dialogueText;


    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                 StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private IEnumerator ShowLine()
    { 
       dialogueText.text = string.Empty;

       foreach(var ch in dialogueLines[lineIndex])
       {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
            
       }
    
    
    
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
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart= false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }


    }

    

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Manager.Instance.player)
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Manager.Instance.player)
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }

    }

}