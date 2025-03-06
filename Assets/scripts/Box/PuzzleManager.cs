using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public PressurePlate[] allPlates; 
    public GameObject door; 
    private bool isSolved = false;

    public int requiredPlates = 3; 

    public AudioSource audioSource; 
    public AudioClip solveSound; 

    private Dictionary<PressurePlate, bool> plateStates = new Dictionary<PressurePlate, bool>();

    private void Start()
    {
        foreach (PressurePlate plate in allPlates)
        {
            plateStates[plate] = false; 
        }
    }

    public void PlateStateChanged(PressurePlate plate, bool isActive)
    {
        if (plateStates[plate] != isActive) 
        {
            plateStates[plate] = isActive;
            CheckPuzzleSolution();
        }
    }

    public void CheckPuzzleSolution()
    {
        if (isSolved) return;

        int correctPlates = 0;

        foreach (var plate in plateStates)
        {
            if (plate.Key.isActivePlate && plate.Value) 
            {
                correctPlates++;
            }
        }

        Debug.Log($"Placas correctas activadas: {correctPlates}");

        if (correctPlates == requiredPlates) 
        {
            Debug.Log("Puzzle resuelto, puerta desbloqueada");
            door.SetActive(false);
            isSolved = true;

            if (audioSource != null && solveSound != null)
            {
                audioSource.PlayOneShot(solveSound);
            }
        }
    }
}
