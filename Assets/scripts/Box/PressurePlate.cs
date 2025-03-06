using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isActivePlate; 
    private bool isPressed = false;
    private PuzzleManager puzzleManager;
    public AudioSource audioSource;
    public AudioClip activateSound;
    public AudioClip deactivateSound;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            if (!isPressed) 
            {
                isPressed = true;
                audioSource.PlayOneShot(activateSound);
                Debug.Log("Placa activada: " + gameObject.name);
                puzzleManager.PlateStateChanged(this, true); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            if (isPressed) 
            {
                isPressed = false;
                audioSource.PlayOneShot(deactivateSound);
                Debug.Log("Placa desactivada: " + gameObject.name);
                puzzleManager.PlateStateChanged(this, false); 
            }
        }
    }
}
