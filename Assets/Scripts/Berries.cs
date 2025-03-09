using System.Collections;
using System.Collections.Generic;
using New;
using UnityEngine;

public class Berries : MonoBehaviour
{
    private bool isPlayerInRange;
    
    private void Start() {
        Manager.Instance.playerInput.OnPressedInteract += Interacted;
    }

    public void Interacted() {
        if (isPlayerInRange) {
            Manager.Instance.player.GetComponent<Health>().Heal(1);
            Manager.Instance.playerInput.OnPressedInteract -= Interacted;
            Destroy(gameObject);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Manager.Instance.player == Collision.gameObject)
        {
            isPlayerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Manager.Instance.player == Collision.gameObject)
        {
            isPlayerInRange = false;
        }
    }
}
