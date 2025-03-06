using System;
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
    public float minTriggerDistance = 0.1f;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            float distance = (collision.gameObject.transform.position - gameObject.transform.position).magnitude;
            
            if (!isPressed) 
            {
                if (distance < minTriggerDistance)
                {
                    isPressed = true;
                    audioSource.PlayOneShot(activateSound);
                    Debug.Log("Placa activada: " + gameObject.name);
                    puzzleManager.PlateStateChanged(this, true); 
                }
            }else {
                if (!(distance < minTriggerDistance))
                {
                    isPressed = false;
                    audioSource.PlayOneShot(deactivateSound);
                    Debug.Log("Placa desactivada: " + gameObject.name);
                    puzzleManager.PlateStateChanged(this, false); 
                }
            }
        }
    }
    
}
