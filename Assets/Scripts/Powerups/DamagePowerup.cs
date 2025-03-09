using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerup : MonoBehaviour
{
    private bool isPlayerInRange;

    private void Start() {
        Manager.Instance.playerInput.OnPressedInteract += Interacted;
    }

    private void Interacted() {
        if (isPlayerInRange) {
            PlayerAttack playerAttack = Manager.Instance.player.GetComponent<PlayerAttack>();
            playerAttack.SetDamage(playerAttack.GetDamage()+1);
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
