using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerup : MonoBehaviour
{
    private bool isPlayerInRange;
    
    
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F)) {
            PlayerAttack playerAttack = Manager.Instance.player.GetComponent<PlayerAttack>();
            playerAttack.SetDamage(playerAttack.GetDamage()+1);
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
